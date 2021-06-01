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
    public class BookingRequestsApi : BaseHttpClientFactory, IBookingRequestsApi
    {
        private readonly ApiConfiguration _config;
        private readonly ILogger<BookingRequestsApi> _log;
        public BookingRequestsApi(IHttpClientFactory factory, IOptions<ApiConfiguration> options,
            ILogger<BookingRequestsApi> log) : base(factory)
        {
            _config = options.Value;
            _builder = new HttpRequestBuilder(_config.BaseAddress);
            _builder.AddToPath(_config.RequestsPath);
            _log = log;
        }

        public async Task<bool> CheckBookingRequest(BookingRequestViewModel request, string token = default)
        {
            using var message = _builder.HttpMethod(HttpMethod.Get).AddToPath($"check/userId={request.UserId}&serviceId={request.ServiceId}").Headers(h =>
                {
                    h.Add("Authorization", "Bearer " + token);
                }).HttpMessage;
            string response = await GetResponseStringAsync(message);
            return response == "true";
        }

        public async Task<bool> CreateBookingRequest(BookingRequestViewModel request, string token = default)
        {
            using var message = _builder.HttpMethod(HttpMethod.Post).
                Content(new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")).Headers(h =>
            {
                h.Add("Authorization", "Bearer " + token);
            }).HttpMessage;
            try
            {
                return await GetResponseStringAsync(message) != null;
            } catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteBookingRequest(Guid id, string token)
        {
            using var message = _builder.HttpMethod(HttpMethod.Delete).AddToPath(id.ToString()).Headers(h =>
            {
                h.Add("Authorization", "Bearer " + token);
            }).HttpMessage;
            try
            {
                return await GetResponseStringAsync(message) != null;
            }
            catch
            {
                return false;
            }
        }
    }
}
