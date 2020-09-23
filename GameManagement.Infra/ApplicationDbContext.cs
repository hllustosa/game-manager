using GameManagement.Domain;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;


namespace GameManagement.Infra
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<IdentityUser>
    {
        public DbSet<Game> Games { get; set; }

        public DbSet<Friend> Friends { get; set; }

        public DbSet<GameLoan> GameLoans { get; set; }

        public ApplicationDbContext(
           DbContextOptions options,
           IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        private void SeedUser(ModelBuilder modelBuilder)
        {
            var userId = Guid.NewGuid().ToString();

            var user = new IdentityUser
            {
                Id = userId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "admin@invillia.com.br",
                NormalizedEmail = "admin@invillia.com.br",
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true
            };

            var password = new PasswordHasher<IdentityUser>();
            var hashed = password.HashPassword(user, "admin");
            user.PasswordHash = hashed;

            //Adding Admin user
            modelBuilder.Entity<IdentityUser>().HasData(user);

            //Adding System Roles
            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "1", Name = "admin", NormalizedName = "admin" },
            new IdentityRole { Id = "2",  Name = "friend", NormalizedName = "friend" });

            //Specifying role for admin user
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                 new IdentityUserRole<string>
                 {
                     RoleId = "1",
                     UserId = userId
                 }
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedUser(modelBuilder);
        }
    }
}
