namespace BookingWeb.ApiCollection.Settings
{
    public interface IApiSettings
    {
        string BaseAddress { get; set; }
        string BookingRequestsPath { get; set; }
        string LeisureServicesPath { get; set; }
        string LeisureServiceCategoriesPath { get; set; }
        string ServiceImagesPath { get; set; }
        string UsersPath { get; set; }
    }
}
