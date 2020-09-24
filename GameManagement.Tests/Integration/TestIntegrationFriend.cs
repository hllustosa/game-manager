using GameManagement.Domain;
using GameManagement.Infra;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using test.utils;
using Xunit;

namespace GameManagement.Tests.Integration
{
    public class TestIntegrationFriend : IDisposable
    {
        public TestContext TestContext { get; set; }

        public ApplicationDbContext Context { get; set; }

        public TestIntegrationFriend()
        {
            TestContext = new TestContext("TestIntegrationFriend.db");
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

        private Friend RetrieveFriend(UserInfo userInfo, long id)
        {
            var url = "/Friend/FindFriendById?id=" + id;
            var result = TestContext.Get(url, userInfo.Token).Result;
            var findFriendResult = result.Content.ReadAsStringAsync().Result;
            var retrievedFriend = JsonConvert.DeserializeObject<Friend>(findFriendResult);
            return retrievedFriend;
        }

        private Friend createFriend(UserInfo userInfo, Friend friend)
        {
            var url = "/Friend/Save";
            var result = TestContext.Post(url, userInfo.Token, friend).Result;
            Assert.Equal(System.Net.HttpStatusCode.OK, result.StatusCode);
            return RetrieveFriend(userInfo, friend.Id);
        }

        private Friend updateFriend(UserInfo userInfo, Friend friend)
        {
            var url = "/Friend/Update";
            var result = TestContext.Post(url, userInfo.Token, friend).Result;
            Assert.Equal(System.Net.HttpStatusCode.OK, result.StatusCode);
            return RetrieveFriend(userInfo, friend.Id);
        }

        private Friend deleteFriend(UserInfo userInfo, Friend friend)
        {
            var url = "/Friend/Delete";
            var result = TestContext.Post(url, userInfo.Token, friend).Result;
            Assert.Equal(System.Net.HttpStatusCode.OK, result.StatusCode);
            return RetrieveFriend(userInfo, friend.Id);
        }

        [Fact]
        public void TEST_CREATE_FRIEND()
        {
            var userInfo = login();
            var friend = new Friend()
            {
                Id = 10,
                Name = "FriendTeste",
            };

            var retrievedFriend = createFriend(userInfo, friend);
            Assert.Equal(friend, retrievedFriend);
        }

        [Fact]
        public void TEST_DUPLICATE_USER()
        {
            var userInfo = login();
            var friend = new Friend()
            {
                Id = 10,
                Name = "FriendTesteDup",
            };

            var retrievedFriend = createFriend(userInfo, friend);
            Assert.Throws<AggregateException>(() => createFriend(userInfo, friend));
        }

        [Fact]
        public void TEST_UPDATE_FRIEND()
        {
            var userInfo = login();
            var friend = new Friend()
            {
                Id = 1001,
                Name = "FriendTesteUp",
            };

            var retrievedFriend = updateFriend(userInfo, friend);
            Assert.Equal(friend, retrievedFriend);
        }

        [Fact]
        public void TEST_DELETE_FRIEND()
        {
            var userInfo = login();
            var friend = new Friend()
            {
                Id = 1001,
                Name = "FriendTesteDelete",
            };

            var retrievedFriend = deleteFriend(userInfo, friend);
            Assert.Null(retrievedFriend);
        }


        [Fact]
        public void Dispose()
        {
            Context.Database.EnsureDeleted();
        }
    }
}
