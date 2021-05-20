using Booking.Users.PWA.Apis.Http;
using Booking.Users.PWA.Apis.Interfaces;
using Booking.Users.PWA.Apis.Settings;
using Booking.Users.PWA.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Users.PWA.Apis
{
    public class UsersApi : BaseHttpClientFactory, IUsersApi
    {
        private readonly ApiConfiguration _config;
        private readonly ILogger<UsersApi> _log;
        public UsersApi(IHttpClientFactory factory, IOptions<ApiConfiguration> options,
            ILogger<UsersApi> log) : base(factory)
        {
            _config = options.Value;
            _builder = new HttpRequestBuilder(_config.BaseAddress);
            _builder.AddToPath(_config.UsersPath);
            _log = log;
        }

        public async Task<UserViewModel> GetUserByIdAsync(Guid id, string token = default)
        {
            using var message = _builder
              .HttpMethod(HttpMethod.Get).AddToPath("/" + id).Headers(h =>
              {
                  h.Add("Authorization", "Bearer " + token);
              })
              .HttpMessage;
            try
            {
                return await GetResponseAsync<UserViewModel>(message);
            }
            catch (ApiException e)
            {
                _log.LogError(e.Message);
                return null;
            }
        }

        public async Task<string> LoginResponseAsync(LoginViewModel user)
        {
            using var message = _builder
              .HttpMethod(HttpMethod.Post).AddToPath("/login").
              Content(new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"))
              .HttpMessage;
                return await GetResponseStringAsync(message);
        }

        public async Task<string> RegisterResponseAsync(RegisterViewModel user)
        {
            using var message = _builder
              .HttpMethod(HttpMethod.Post).AddToPath("/register").
              Content(new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"))
              .HttpMessage;
                return await GetResponseStringAsync(message);
        }

        public async Task<bool> UpdateUserAsync(UpdateUserViewModel user, string token = default)
        {

            using var message = _builder
              .HttpMethod(HttpMethod.Put).AddToPath("/" + user.Id).Headers(h =>
              {
                  h.Add("Authorization", "Bearer " + token);
              }).
              Content(new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"))
              .HttpMessage;
            try
            {
                return (await GetResponseStringAsync(message)) != null;
            }
            catch (ApiException e)
            {
                _log.LogError(e.Message);
                return false;
            }
        }
    }
}
