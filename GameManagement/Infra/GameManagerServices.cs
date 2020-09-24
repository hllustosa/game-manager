using GameManagement.Repositories.Interfaces;
using GameManagement.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;
using GameManagement.Services.Interfaces;
using GameManagement.Services;
using GameManagement.services.interfaces;

namespace GameManagement.Infra
{
    public static class GameManagerServices
    {
        public const string ADMIN_ROLE = "admin";
        public const string ADMIN_ROLE_POLICY = "ADMIN_ROLE_POLICY";

        public const string FRIEND_ROLE = "friend";
        public const string FRIEND_ROLE_POLICY = "FRIEND_ROLE_POLICY";

        public static void AddGameManagerServices(this IServiceCollection services, IConfiguration configuration, bool testing = false)
        {
            #region Add Database Context
            if (!testing)
            {
                services.AddEntityFrameworkSqlite().AddDbContext<ApplicationDbContext>(
                    options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("GameManagement")));
            }
            #endregion

            #region Add Identity
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            #endregion

            #region Add Authetication
            var issuer = configuration.GetValue<string>("issuer");
            var key = configuration.GetValue<string>("key");
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("Token-Expired", "true");
                            }
                            return Task.CompletedTask;
                        },
                    };

                });
            #endregion

            #region Add Authorization
            services.AddAuthorization(options =>
            {
                options.AddPolicy(ADMIN_ROLE_POLICY, policy => policy.RequireClaim(ADMIN_ROLE));
                options.AddPolicy(FRIEND_ROLE_POLICY, policy => policy.RequireClaim(FRIEND_ROLE));

            });
            #endregion

            #region Add Repositories
            services.AddTransient<IFriendRepository, FriendRepository>();
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<IGameLoanRepository, GameLoanRepository>();
            #endregion

            #region Add Services
            services.AddTransient<IFriendService, FriendService>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IGameLoanService, GameLoanService>();
            services.AddTransient<IDateService, DateService>();
            services.AddTransient<IUserService, UserService>();
            #endregion

        }
    }
}
