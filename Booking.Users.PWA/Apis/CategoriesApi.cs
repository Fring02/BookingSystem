using Booking.Users.PWA.Apis.Http;
using Booking.Users.PWA.Apis.Interfaces;
using Booking.Users.PWA.Apis.Settings;
using Booking.Users.PWA.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Booking.Users.PWA.Apis
{
    public class CategoriesApi : BaseHttpClientFactory, ICategoriesApi
    {
        private readonly ApiConfiguration _config;
        private readonly ILogger<CategoriesApi> _log;
        public CategoriesApi(IHttpClientFactory factory, IOptions<ApiConfiguration> options,
            ILogger<CategoriesApi> log) : base(factory)
        {
            _config = options.Value;
            _builder = new HttpRequestBuilder(_config.BaseAddress);
            _builder.AddToPath(_config.CategoriesPath);
            _log = log;
        }
        public async Task<IEnumerable<LeisureServiceCategoryViewModel>> GetAllCategories()
        {
            using var message = _builder
              .HttpMethod(HttpMethod.Get)
              .HttpMessage;
            try
            {
                var categories = await GetResponseAsync<IEnumerable<LeisureServiceCategoryViewModel>>(message);
                if (categories == null) _log.LogWarning("Did not found categories by uri " + _builder.HttpMessage.RequestUri.LocalPath);
                return categories;
            }
            catch (ApiException e)
            {
                _log.LogError(e.Message);
                return null;
            }
        }
    }
}
