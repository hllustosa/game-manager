using GameManagement.Domain;
using GameManagement.Infra;
using Newtonsoft.Json;
using test.utils;
using Xunit;

namespace GameManagement.Tests.Integration
{
    public class TestIntegrationGame
    {
        public TestContext TestContext { get; set; }

        public ApplicationDbContext Context { get; set; }

        public TestIntegrationGame()
        {
            TestContext = new TestContext("TestIntegrationGame.db");
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

        private Game RetrieveGame(UserInfo userInfo, long id)
        {
            var url = "/api/Games/" + id;
            var result = TestContext.Get(url, userInfo.Token).Result;
            var findGameResult = result.Content.ReadAsStringAsync().Result;
            var retrievedGame = JsonConvert.DeserializeObject<Game>(findGameResult);
            return retrievedGame;
        }

        private Game createGame(UserInfo userInfo, Game game)
        {
            var url = "/api/Games/";
            var result = TestContext.Post(url, userInfo.Token, game).Result;
            Assert.Equal(System.Net.HttpStatusCode.OK, result.StatusCode);
            return RetrieveGame(userInfo, game.Id);
        }

        private Game updateGame(UserInfo userInfo, Game game)
        {
            var url = "/api/Games/"+game.Id;
            var result = TestContext.Put(url, userInfo.Token, game).Result;
            Assert.Equal(System.Net.HttpStatusCode.OK, result.StatusCode);
            return RetrieveGame(userInfo, game.Id);
        }

        private Game deleteGame(UserInfo userInfo, Game game)
        {
            var url = "/api/Games/" + game.Id;
            var result = TestContext.Delete(url, userInfo.Token, game).Result;
            Assert.Equal(System.Net.HttpStatusCode.OK, result.StatusCode);
            return RetrieveGame(userInfo, game.Id);
        }

        [Fact]
        public void TEST_CREATE_GAME()
        {
            var userInfo = login();
            var game = new Game()
            {
                Id = 10,
                Name = "GameTeste",
                IsLent = false,
                MediaType  = 1,
                PlataformName = "PlatformTest"
            };

            var retrievedGame = createGame(userInfo, game);
            Assert.Equal(game, retrievedGame);
        }


        [Fact]
        public void TEST_UPDATE_GAME()
        {
            var userInfo = login();
            var game = new Game()
            {
                Id = 1001,
                Name = "GameTesteUp",
                IsLent = true,
                MediaType = 1,
                PlataformName = "PlatformTest"
            };

            var retrievedGame = updateGame(userInfo, game);
            Assert.Equal(game, retrievedGame);
        }

        [Fact]
        public void TEST_DELETE_GAME()
        {
            var userInfo = login();
            var game = new Game()
            {
                Id = 1001,
                Name = "GameTesteDel",
                IsLent = false,
                MediaType = 1,
                PlataformName = "PlatformTest"
            };

            var retrievedGame = deleteGame(userInfo, game);
            Assert.Null(retrievedGame);
        }

    }
}
