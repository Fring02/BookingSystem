using BookingWeb.ApiCollection.Infrastructure;
using BookingWeb.ApiCollection.Interfaces;
using BookingWeb.ApiCollection.Settings;
using BookingWeb.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookingWeb.ApiCollection.APIs
{
    public class UsersApi : BaseHttpClientWithFactory, IUsersApi
    {

        private IApiSettings _settings;
        public UsersApi(IHttpClientFactory factory, IApiSettings settings) : base(factory)
        {
            _settings = settings;
            _builder = new HttpRequestBuilder(_settings.BaseAddress);
            _builder.AddToPath(_settings.UsersPath);
        }

       

       

        public async Task RegisterOwner(RegisterDTO registerForm)
        {
            using var message = _builder.AddToPath("register")
           .HttpMethod(HttpMethod.Post).
           Content(new StringContent(JsonConvert.SerializeObject(registerForm), Encoding.UTF8, "application/json"))
           .GetHttpMessage();
            await SendRequestAsync<RegisterDTO>(message);
        }

        public async Task<User> GetUserById(Guid id)
        {
            using var message = _builder
            .HttpMethod(HttpMethod.Get).AddToPath(id.ToString())
            .GetHttpMessage();
            return await GetResponseAsync<User>(message);
        }

        public async Task<string> AuthentificationToken(User user)
        {
            using var message = new HttpRequestBuilder(_settings.BaseAddress + _settings.UsersPath)
            .HttpMethod(HttpMethod.Post).AddToPath("/login").
            Content(new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"))
            .GetHttpMessage();
            return await GetResponseStringAsync(message);
        }

        public async Task<string> RegistrationToken(User user)
        {
            using var message = new HttpRequestBuilder(_settings.BaseAddress + _settings.UsersPath)
            .HttpMethod(HttpMethod.Post).AddToPath("/register").
            Content(new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"))
            .GetHttpMessage();
            return await GetResponseStringAsync(message);
        }

        public async Task<bool> UpdateUser(User user)
        {
            _builder.AddToPath(_settings.UsersPath);
            using var message = _builder
           .HttpMethod(HttpMethod.Put).AddToPath("/" + user.Id).
           Content(new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"))
           .GetHttpMessage();
            return await GetResponseStringAsync(message) != null;

        }

        public override async Task<string> GetResponseStringAsync(HttpRequestMessage request)
        {
            using var client = GetHttpClient();
            using var response = await client.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
