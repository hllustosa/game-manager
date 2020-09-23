using GameManagement.Domain;
using GameManagement.Infra;
using GameManagement.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GameManagement.Services
{
    public class UserService : IUserService
    {
        private ApplicationDbContext ApplicationDbContext { get; set; }

        private UserManager<IdentityUser> UserManager { get; set; }

        private SignInManager<IdentityUser> SignInManager { get; set; }

        private IConfiguration Configuration { get; set; }

        private IHttpContextAccessor ContextAcessor { get; set; }

        private IDateService DateService { get; set; }

        public UserService(ApplicationDbContext applicationDbContext, 
            UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager, 
            IConfiguration configuration, 
            IHttpContextAccessor contextAcessor, 
            IDateService dateService)
        {
            ApplicationDbContext = applicationDbContext;
            UserManager = userManager;
            SignInManager = signInManager;
            Configuration = configuration;
            ContextAcessor = contextAcessor;
            DateService = dateService;
        }

        private IdentityUser FindUser(string userName)
        {
            var user = UserManager.FindByNameAsync(userName).Result;

            if (user == null)
            {
                user = UserManager.FindByEmailAsync(userName).Result;
            }

            if (user == null)
            {
                throw new GameManagerException("Usuário não encontrado", StatusCodes.Status401Unauthorized);
            }

            return user;
        }

        private string GenerateToken(IdentityUser user)
        {
            var key = Configuration.GetValue<string>("key");
            var issuer = Configuration.GetValue<string>("issuer");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var permClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };

            var token = new JwtSecurityToken(issuer,
                            issuer,
                            permClaims,
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: credentials);

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }

        public UserInfo GetCurrentUser()
        {
            if (ContextAcessor.HttpContext.User != null)
            {
                var userId = ContextAcessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var user = UserManager.FindByIdAsync(userId).Result;

                if (user != null)
                {
                    return new UserInfo()
                    {
                        UserId = user.Id,
                        Name = user.UserName,
                        Token = ""
                    };
                }
            }

            throw new GameManagerException("Usuário inválido", StatusCodes.Status403Forbidden);
        }

        public void CreateUserFromFriend(Friend friend)
        {
            var user = new IdentityUser
            {
                UserName = friend.Name,
                NormalizedUserName = friend.Name,
                Email = friend.Name+"@invillia.com.br",
                NormalizedEmail = friend.Name + "@invillia.com.br",
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true
            };

            _ = UserManager.CreateAsync(user, friend.Name).Result;
        }

        public UserInfo Login(string userName, string password)
        {
            var userToSignIn = FindUser(userName);
            var result = SignInManager.PasswordSignInAsync(userToSignIn, password, false, true).Result;
           
            if (result.IsLockedOut)
            {
                throw new GameManagerException("Usuário não pode fazer login", StatusCodes.Status401Unauthorized);
            }

            if (!result.Succeeded)
            {
                throw new GameManagerException("Problema de autenticação", StatusCodes.Status401Unauthorized);
            }

            var token = GenerateToken(userToSignIn);
            return new UserInfo()
            {
                UserId = userToSignIn.Id,
                Name = userToSignIn.UserName,
                Token = token,
                TokenExp = DateService.GetCurrentDate().AddDays(1)
            };
        }
    }
}
