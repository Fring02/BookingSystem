using BookingWeb.ApiCollection.Settings;

namespace BookingWeb.ApiCollection.Settings
{
    public class ApiSettings : IApiSettings
    {
        public string BaseAddress { get; set; }
        public string BookingRequestsPath { get; set; }
        public string LeisureServicesPath { get; set; }
        public string LeisureServiceCategoriesPath { get; set; }
        public string ServiceImagesPath { get; set; }
        public string UsersPath { get; set; }
    }
}
