using GameManagement.Domain;
using GameManagement.Infra;
using Newtonsoft.Json;
using System;
using test.utils;
using Xunit;

namespace GameManagement.Tests.Integration
{
    public class TestIntegrationGameLoan
    {
        public TestContext TestContext { get; set; }

        public ApplicationDbContext Context { get; set; }

        public TestIntegrationGameLoan()
        {
            TestContext = new TestContext("TestIntegrationGameLoan.db");
            Context = TestContext.Context;
        }

        private UserInfo login()
        {
            var url = "/User/Login";
            var result = TestContext.Post(url, new UserLogin() { UserName = "admin", Password = "admin" }).Result;
            Assert.Equal(System.Net.HttpStatusCode.OK, result.StatusCode);

            var loginResult = result.Content.ReadAsStringAsync().Result;
            var userInfo = JsonConvert.DeserializeObject<UserInfo>(loginResult);

            return userInfo;
        }

        private GameLoan RetrieveGameLoan(UserInfo userInfo, long id)
        {
            var url = "/GameLoan/FindGameLoanById?id=" + id;
            var result = TestContext.Get(url, userInfo.Token).Result;
            var findGameLoanResult = result.Content.ReadAsStringAsync().Result;
            var retrievedGameLoan = JsonConvert.DeserializeObject<GameLoan>(findGameLoanResult);
            return retrievedGameLoan;
        }

        private GameLoan createGameLoan(UserInfo userInfo, GameLoan gameLoan)
        {
            var url = "/GameLoan/Save";
            var result = TestContext.Post(url, userInfo.Token, gameLoan).Result;
            Assert.Equal(System.Net.HttpStatusCode.OK, result.StatusCode);
            return RetrieveGameLoan(userInfo, gameLoan.Id);
        }

        private GameLoan updateGameLoan(UserInfo userInfo, GameLoan gameLoan)
        {
            var url = "/GameLoan/Update";
            var result = TestContext.Post(url, userInfo.Token, gameLoan).Result;
            Assert.Equal(System.Net.HttpStatusCode.OK, result.StatusCode);
            return RetrieveGameLoan(userInfo, gameLoan.Id);
        }

        private GameLoan deleteGame(UserInfo userInfo, GameLoan gameLoan)
        {
            var url = "/GameLoan/Delete";
            var result = TestContext.Post(url, userInfo.Token, gameLoan).Result;
            Assert.Equal(System.Net.HttpStatusCode.OK, result.StatusCode);
            return RetrieveGameLoan(userInfo, gameLoan.Id);
        }

        private void createGame(UserInfo userInfo, Game game)
        {
            var url = "/Game/Save";
            var result = TestContext.Post(url, userInfo.Token, game).Result;
            Assert.Equal(System.Net.HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void TEST_CREATE_GAMELOAN()
        {
            var userInfo = login();

            var game = new Game()
            {
                Id = 10,
                Name = "GameTeste",
                IsLent = false,
                MediaType = 1,
                PlataformName = "PlatformTest"
            };
            createGame(userInfo, game);

            var gameLoan = new GameLoan()
            {
                Id = 1000001,
                FriendId = 1010,
                GameId = 10,
                IsActive = true,
                LoanDate = DateTime.MinValue
            };

            var retrievedGameLoan = createGameLoan(userInfo, gameLoan);
            Assert.Equal(gameLoan, retrievedGameLoan);
        }


        [Fact]
        public void TEST_CREATE_GAMELOAN_FOR_LOANED_GAME()
        {
            var userInfo = login();

            var game = new Game()
            {
                Id = 11,
                Name = "GameTeste",
                IsLent = false,
                MediaType = 1,
                PlataformName = "PlatformTest"
            };
            createGame(userInfo, game);

            var gameLoan = new GameLoan()
            {
                Id = 1000011,
                FriendId = 1010,
                GameId = 11,
                IsActive = true,
                LoanDate = DateTime.MinValue
            };

            createGameLoan(userInfo, gameLoan);
            gameLoan.Id = 1000012;
            Assert.Throws<AggregateException>(() => createGameLoan(userInfo, gameLoan));
        }

        [Fact]
        public void TEST_UPDATE_GAMELOAN()
        {
            var userInfo = login();
            
            var game = new Game()
            {
                Id = 12,
                Name = "GameTeste",
                IsLent = false,
                MediaType = 1,
                PlataformName = "PlatformTest"
            };
            createGame(userInfo, game);

            var gameLoan = new GameLoan()
            {
                Id = 1000014,
                FriendId = 1010,
                GameId = 12,
                IsActive = true,
                LoanDate = DateTime.MinValue
            };
            createGameLoan(userInfo, gameLoan);

            gameLoan = new GameLoan()
            {
                Id = 1000014,
                FriendId = 1012,
                GameId = 12,
                IsActive = true,
                LoanDate = DateTime.MinValue
            };
            var retrievedGameLoan = updateGameLoan(userInfo, gameLoan);
            Assert.Equal(gameLoan, retrievedGameLoan);
        }

        [Fact]
        public void TEST_MARK_GAMELOAN_AS_RETURNED()
        {
            var userInfo = login();

            var game = new Game()
            {
                Id = 13,
                Name = "GameTeste",
                IsLent = false,
                MediaType = 1,
                PlataformName = "PlatformTest"
            };
            createGame(userInfo, game);

            var gameLoan = new GameLoan()
            {
                Id = 1000015,
                FriendId = 1010,
                GameId = 13,
                IsActive = true,
                LoanDate = DateTime.MinValue
            };
            createGameLoan(userInfo, gameLoan);

            gameLoan = new GameLoan()
            {
                Id = 1000015,
                FriendId = 1010,
                GameId = 13,
                IsActive = false,
                LoanDate = DateTime.MinValue,
                ReturnDate = DateTime.MinValue
            };
            var retrievedGameLoan = updateGameLoan(userInfo, gameLoan);
            Assert.Equal(gameLoan, retrievedGameLoan);
        }

        [Fact]
        public void TEST_DELETE_GAMELOAN()
        {
            var userInfo = login();

            var game = new Game()
            {
                Id = 14,
                Name = "GameTeste",
                IsLent = false,
                MediaType = 1,
                PlataformName = "PlatformTest"
            };
            createGame(userInfo, game);

            var gameLoan = new GameLoan()
            {
                Id = 1000016,
                FriendId = 1010,
                GameId = 14,
                IsActive = true,
                LoanDate = DateTime.MinValue
            };
            createGameLoan(userInfo, gameLoan);

            var retrievedGameLoan = deleteGame(userInfo, gameLoan);
            Assert.Null(retrievedGameLoan);
        }
    }
}
