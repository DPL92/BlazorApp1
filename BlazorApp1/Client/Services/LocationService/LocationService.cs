using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorApp1.Client.Services.LocationService
{
    public class LocationService: ILocationService
    {
        private readonly HttpClient _http;

        private readonly NavigationManager _navigationManager;

        public LocationService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }


        public List<Location> locations { get; set; } = new List<Location>();

        public async Task CreateLocation(Location l)
        {
            var res = await _http.PostAsJsonAsync("api/location", l);

            await SetLocations(res);
        }

        public async Task DeleteLocation(int id)
        {
            var res = await _http.DeleteAsync($"api/location/{id}");
            await SetLocations(res);
        }

        private async Task SetLocations(HttpResponseMessage res)
        {
            var response = await res.Content.ReadFromJsonAsync<List<Location>>();
            locations = response;
            _navigationManager.NavigateTo("locations");

        }


        public async Task<Location> GetSingleLocation(int id)
        {

            var res = await _http.GetFromJsonAsync<Location>($"api/location/{id}");
            if (res != null)
                return res;
            throw new Exception("Location not found");
        }

        public async Task GetLocations()
        {

            var res = await _http.GetFromJsonAsync<List<Location>>("api/location");
            if (res != null) locations = res;
        }

        public async Task UpdateLocation(Location l)
        {
            var res = await _http.PutAsJsonAsync($"api/location/{l.locationId}", l);
            await SetLocations(res);
        }














    }
}
