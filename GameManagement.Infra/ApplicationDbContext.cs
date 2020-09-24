using GameManagement.Domain;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace GameManagement.Infra
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<IdentityUser>
    {
        Game[] GamesExamples = new Game[]
        {
            new Game() { Id = 1001, Name = "Haverst Moon: Back to Nature", IsLent = true, MediaType = (int)MediaType.CD, PlataformName = "PlayStation" },
            new Game() { Id = 1002, Name = "Super Mario World", IsLent = true, MediaType = (int)MediaType.Cartridge, PlataformName = "SNES" },
            new Game() { Id = 1003, Name = "Pokemon Yellow", IsLent = true, MediaType = (int)MediaType.Cartridge, PlataformName = "Game Boy Color" },
            new Game() { Id = 1004, Name = "The Witcher III", IsLent = true, MediaType = (int)MediaType.BLURAY, PlataformName = "XBox One" },
            new Game() { Id = 1005, Name = "The Prince Of Persia", IsLent = true, MediaType = (int)MediaType.BLURAY, PlataformName = "PlayStation 4" },
            new Game() { Id = 1006, Name = "Halo", IsLent = true, MediaType = (int)MediaType.BLURAY, PlataformName = "XBox One" },
            new Game() { Id = 1007, Name = "The Last of Us II", IsLent = true, MediaType = (int)MediaType.BLURAY, PlataformName = "PlayStation 4" },
            new Game() { Id = 1008, Name = "Rocket League", IsLent = true, MediaType = (int)MediaType.BLURAY, PlataformName = "XBox One" },
            new Game() { Id = 1009, Name = "Magicka", IsLent = true, MediaType = (int)MediaType.BLURAY, PlataformName = "XBox One" },
            new Game() { Id = 1010, Name = "Kill Zone", IsLent = true, MediaType = (int)MediaType.BLURAY, PlataformName = "PlayStation 4" },
            new Game() { Id = 1011, Name = "Street Fighter", IsLent = true, MediaType = (int)MediaType.BLURAY, PlataformName = "XBox One" },
            new Game() { Id = 1012, Name = "Uncharted", IsLent = true, MediaType = (int)MediaType.BLURAY, PlataformName = "PlayStation 4" },
            new Game() { Id = 1013, Name = "The Spider Man", IsLent = true, MediaType = (int)MediaType.BLURAY, PlataformName = "XBox One" },
            new Game() { Id = 1014, Name = "The Arkan Assilum", IsLent = true, MediaType = (int)MediaType.BLURAY, PlataformName = "PlayStation 4" },
            new Game() { Id = 1015, Name = "Gear of War", IsLent = true, MediaType = (int)MediaType.BLURAY, PlataformName = "XBox One" },
            new Game() { Id = 1016, Name = "Minecraft", IsLent = true, MediaType = (int)MediaType.BLURAY, PlataformName = "PlayStation 4" },
            new Game() { Id = 1017, Name = "GTA V", IsLent = true, MediaType = (int)MediaType.BLURAY, PlataformName = "XBox One" },
            new Game() { Id = 1018, Name = "Resident Evil", IsLent = true, MediaType = (int)MediaType.BLURAY, PlataformName = "PlayStation 4" },
            new Game() { Id = 1019, Name = "DBZ Zenoverse", IsLent = true, MediaType = (int)MediaType.BLURAY, PlataformName = "XBox One" },
            new Game() { Id = 1020, Name = "God of War", IsLent = true, MediaType = (int)MediaType.BLURAY, PlataformName = "PlayStation 4" },
            new Game() { Id = 1021, Name = "Just Dance", IsLent = true, MediaType = (int)MediaType.BLURAY, PlataformName = "XBox One" },
            new Game() { Id = 1022, Name = "The Mortal Kombat", IsLent = true, MediaType = (int)MediaType.BLURAY, PlataformName = "PlayStation 4" },
            new Game() { Id = 1023, Name = "Dragon Age", IsLent = true, MediaType = (int)MediaType.BLURAY, PlataformName = "XBox One" },
            new Game() { Id = 1024, Name = "Skyrim", IsLent = true, MediaType = (int)MediaType.BLURAY, PlataformName = "PlayStation 4" },
            new Game() { Id = 1025, Name = "Red Dead Redemption", IsLent = true, MediaType = (int)MediaType.BLURAY, PlataformName = "XBox One" },
            new Game() { Id = 1026, Name = "NBA 2k20", IsLent = true, MediaType = (int)MediaType.BLURAY, PlataformName = "PlayStation 4" },
            new Game() { Id = 1027, Name = "Fifa 2020", IsLent = true, MediaType = (int)MediaType.BLURAY, PlataformName = "XBox One" }
        };

        Friend[] FriendsExamples = new Friend[]
        {
            new Friend() { Id = 1001, Name = "Eduardo"},
            new Friend() { Id = 1002, Name = "Ayla"},
            new Friend() { Id = 1003, Name = "Juliana" },
            new Friend() { Id = 1004, Name = "Carlos" },
            new Friend() { Id = 1005, Name = "Julia" },
            new Friend() { Id = 1006, Name = "Fernanda" },
            new Friend() { Id = 1007, Name = "Pedro" },
            new Friend() { Id = 1008, Name = "Manuela" },
            new Friend() { Id = 1009, Name = "Mateus" },
            new Friend() { Id = 1010, Name = "Jorge" },
            new Friend() { Id = 1011, Name = "Antônia" },
            new Friend() { Id = 1012, Name = "Rodolfo" },
            new Friend() { Id = 1013, Name = "Cezar" },
            new Friend() { Id = 1014, Name = "Julia" },
            new Friend() { Id = 1015, Name = "Ana" },
            new Friend() { Id = 1016, Name = "Fabio" },
            new Friend() { Id = 1017, Name = "Marta" },
            new Friend() { Id = 1018, Name = "Henrique" },
            new Friend() { Id = 1019, Name = "Enzo" }
        };


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
                NormalizedUserName = "ADMIN",
                Email = "admin@invillia.com.br",
                NormalizedEmail = ("admin@invillia.com.br").ToUpper(),
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
            new IdentityRole { Id = "1", Name = "admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "2",  Name = "friend", NormalizedName = "FRIEND" });

            //Specifying role for admin user
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                 new IdentityUserRole<string>
                 {
                     RoleId = "1",
                     UserId = userId
                 }
            );
        }

        void SeedGames(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasData(GamesExamples);
        }

        void SeedFriends(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>().HasData(FriendsExamples);
        }

        void SeedLoans(ModelBuilder modelBuilder)
        {
            var loans = new List<GameLoan>();
            for(int i = 0; i < GamesExamples.Length; i++)
            {
                for(int j = 0; j < FriendsExamples.Length; j++)
                {
                    var index = i * FriendsExamples.Length + j;
                    var active = FriendsExamples[j].Id == GamesExamples[i].Id;
                    DateTime? returnDate = null;

                    if (!active)
                    {
                        returnDate = DateTime.ParseExact("25/01/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(index);
                    }

                    var loan = new GameLoan()
                    {
                        Id = 1000 + index,
                        FriendId = FriendsExamples[j].Id,
                        GameId = GamesExamples[i].Id,
                        IsActive = active,
                        LoanDate = DateTime.ParseExact("22/01/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(index),
                        ReturnDate = returnDate
                    };
                    loans.Add(loan);
                }
            }
            modelBuilder.Entity<GameLoan>().HasData(loans.ToArray());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedUser(modelBuilder);
            SeedGames(modelBuilder);
            SeedFriends(modelBuilder);
            SeedLoans(modelBuilder);
        }
    }
}
