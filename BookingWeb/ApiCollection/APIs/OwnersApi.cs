using BookingWeb.ApiCollection.Infrastructure;
using BookingWeb.ApiCollection.Interfaces;
using BookingWeb.ApiCollection.Settings;
using BookingWeb.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookingWeb.ApiCollection.APIs
{
    public class OwnersApi : BaseHttpClientFactory, IOwnersApi
    {
        private readonly ApiSettings _config;
        private readonly ILogger<OwnersApi> _log;
        public OwnersApi(IHttpClientFactory factory, IOptions<ApiSettings> options,
            ILogger<OwnersApi> log) : base(factory)
        {
            _config = options.Value;
            _builder = new HttpRequestBuilder(_config.BaseAddress);
            _builder.AddToPath(_config.OwnersPath);
            _log = log;
        }

        public async Task<string> LoginOwnerAsync(LoginDTO loginForm)
        {
            using var message = _builder
              .HttpMethod(HttpMethod.Post).AddToPath("/login").
              Content(new StringContent(JsonConvert.SerializeObject(loginForm), Encoding.UTF8, "application/json"))
              .HttpMessage;
            return await GetResponseStringAsync(message);
        }

        public async Task<string> RegisterOwnerAsync(RegisterDTO registerDtoForm)
        {
            using var message = _builder
              .HttpMethod(HttpMethod.Post).AddToPath("/register").
              Content(new StringContent(JsonConvert.SerializeObject(registerDtoForm), Encoding.UTF8, "application/json"))
              .HttpMessage;
            return await GetResponseStringAsync(message);
        }


        
        public async Task<OwnerProfileModel> GetOwnerByIdAsync(Guid id, string token = default)
        {
            using var message = _builder
              .HttpMethod(HttpMethod.Get).AddToPath("/" + id).Headers(h =>
              {
                  h.Add("Authorization", "Bearer " + token);
              })
              .HttpMessage;
            try
            {
                return await GetResponseAsync<OwnerProfileModel>(message);
            }
            catch (ApiException e)
            {
                _log.LogError(e.Message);
                return null;
            }
        }

       /* public async Task<string> LoginResponseAsync(LoginViewModel user)
        {
            using var message = _builder
              .HttpMethod(HttpMethod.Post).AddToPath("/login").
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
        */
    }
}
