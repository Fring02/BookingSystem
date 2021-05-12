using BookingWeb.ApiCollection.Infrastructure;
using BookingWeb.ApiCollection.Interfaces;
using BookingWeb.ApiCollection.Settings;
using BookingWeb.Models;
using Newtonsoft.Json;
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
    }
}
