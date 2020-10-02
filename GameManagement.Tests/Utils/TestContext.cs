using GameManagement.Infra;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using utils.test;

namespace test.utils
{
    public class TestContext : IDisposable
    {
        public HttpClient Client { get; set; }

        public TestServer Server { get; set; }

        public ApplicationDbContext Context { get; set; }

        public TestContext(string connectionString)
        {
            SetupClient(connectionString);
        }

        private void SetupClient(string connectionString)
        {
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("connectionString", connectionString),
                    new KeyValuePair<string, string>("issuer", "http://localhost:5001"),
                    new KeyValuePair<string, string>("key",  "99848aaa-7a56-44d1-a14b-31fe95da2e48"),
                })
                .Build();

            var host = new WebHostBuilder()
                .UseConfiguration(config)
                .UseStartup<TestStartup>();

            Server = new TestServer(host);

            Context = (ApplicationDbContext)Server.Services.GetService(typeof(ApplicationDbContext));
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();

            Client = Server.CreateClient();
        }

        public async Task<HttpResponseMessage> Get(string url)
        {
            return await Client.GetAsync(url);
        }

        public async Task<HttpResponseMessage> Get(string url, string token)
        {
            if (!Client.DefaultRequestHeaders.Contains("Authorization"))
                Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            return await Client.GetAsync(url);
        }

        public async Task<HttpResponseMessage> Post(string url, Object obj)
        {
            var jsonContent = JsonConvert.SerializeObject(obj);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new
            MediaTypeHeaderValue("application/json");
            return await Client.PostAsync(url, contentString);
        }

        public async Task<HttpResponseMessage> Post(string url, string token, Object obj)
        {
            var jsonContent = JsonConvert.SerializeObject(obj);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new
            MediaTypeHeaderValue("application/json");
            if (!Client.DefaultRequestHeaders.Contains("Authorization"))
                Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            return await Client.PostAsync(url, contentString);
        }

        public async Task<HttpResponseMessage> Put(string url, string token, Object obj)
        {
            var jsonContent = JsonConvert.SerializeObject(obj);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new
            MediaTypeHeaderValue("application/json");
            if (!Client.DefaultRequestHeaders.Contains("Authorization"))
                Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            return await Client.PutAsync(url, contentString);
        }

        public async Task<HttpResponseMessage> Delete(string url, string token, Object obj)
        {
            var jsonContent = JsonConvert.SerializeObject(obj);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new
            MediaTypeHeaderValue("application/json");
            if (!Client.DefaultRequestHeaders.Contains("Authorization"))
                Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            return await Client.DeleteAsync(url);
        }

        public async Task<HttpResponseMessage> Post(string url, string token, MultipartFormDataContent content)
        {
            if (!Client.DefaultRequestHeaders.Contains("Authorization"))
                Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            return await Client.PostAsync(url, content);
        }

        public void Dispose()
        {
            //DbTest.RemoveTestDB();
        }
    }
}
