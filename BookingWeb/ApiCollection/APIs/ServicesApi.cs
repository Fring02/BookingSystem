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
    public class ServicesApi : BaseHttpClientFactory, IServicesApi
    {
        private readonly ApiSettings _config;
        private readonly ILogger<ServicesApi> _log;
        
        public ServicesApi(IHttpClientFactory factory, IOptions<ApiSettings> options,
           ILogger<ServicesApi> log) : base(factory)
        {
            _config = options.Value;
            _builder = new HttpRequestBuilder(_config.BaseAddress);
            _builder.AddToPath(_config.ServicesPath);
            _log = log;
        }
        public async Task<IEnumerable<LeisureServiceElementViewModel>> GetAllServices()
        {
            using var message = _builder
             .HttpMethod(HttpMethod.Get)
             .HttpMessage;
            try
            {
                var services = await GetResponseAsync<IEnumerable<LeisureServiceElementViewModel>>(message);
                if (services == null) _log.LogWarning("Did not found services by uri " + _builder.HttpMessage.RequestUri.LocalPath);
                return services;
            }
            catch (ApiException e)
            {
                _log.LogError(e.Message);
                return null;
            }
        }

        public async Task<IEnumerable<LeisureServiceElementViewModel>> GetFilteredServices(string categoryName = null, int? rating = null,
            string workingTime = null, string name = null)
        {
            try
            {
                if (name != null)
                {
                    _builder = _builder.AddQueryString("name", name);
                }
                if (categoryName != null) _builder = _builder.AddQueryString("categoryName", categoryName);
                if (rating.HasValue) _builder = _builder.AddQueryString("rating", rating.ToString());
                if (workingTime != null) _builder = _builder.AddQueryString("workingTime", workingTime);
                var services = await GetResponseAsync<IEnumerable<LeisureServiceElementViewModel>>(_builder.HttpMethod(HttpMethod.Get).HttpMessage);
                if (services == null) _log.LogWarning("Did not found services by uri " + _builder.HttpMessage.RequestUri.LocalPath);
                return services;
            }
            catch (ApiException e)
            {
                _log.LogError(e.Message);
                return null;
            }
            finally
            {
                _builder.Dispose();
            }
        }

        public async Task<IEnumerable<LeisureServiceElementViewModel>> GetPopularServices(int count)
        {
            using var message = _builder.AddToPath("/popular").AddQueryString("count", count.ToString())
             .HttpMethod(HttpMethod.Get)
             .HttpMessage;
            try
            {
                var services = await GetResponseAsync<IEnumerable<LeisureServiceElementViewModel>>(message);
                if (services == null) _log.LogWarning("Did not found services by uri " + _builder.HttpMessage.RequestUri.LocalPath);
                return services;
            }
            catch (ApiException e)
            {
                _log.LogError(e.Message);
                return null;
            }
        }

        public async Task<LeisureServiceViewModel> GetServiceById(Guid id)
        {
            using var message = _builder.AddToPath("/" + id)
             .HttpMethod(HttpMethod.Get)
             .HttpMessage;
            try
            {
                var service = await GetResponseAsync<LeisureServiceViewModel>(message);
                if (service == null) _log.LogWarning("Did not found service by uri " + _builder.HttpMessage.RequestUri.LocalPath);
                return service;
            }
            catch (ApiException e)
            {
                _log.LogError(e.Message);
                return null;
            }
        }

        public async Task<bool> UpdateService(Guid id, int rating, string token)
        {
            var service = new LeisureServiceViewModel
            {
                Rating = rating
            };
            using var message = _builder.AddToPath("/" + id).Content(new StringContent(JsonConvert.SerializeObject(service), Encoding.UTF8,
                "application/json")).Headers(h =>
                {
                    h.Add("Authorization", "Bearer " + token);
                })
             .HttpMethod(HttpMethod.Put)
             .HttpMessage;
            return await GetResponseStringAsync(message) != null;
        }

        public override async Task<string> GetResponseStringAsync(HttpRequestMessage request)
        {
            using var client = Client;
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            try
            {
                return await response.Content.ReadAsStringAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}
