using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
namespace BlazorApp1.Client.Services.VehicleService
{
    public class VehicleService : IVehicleService
    {
        private readonly HttpClient _http;

        private readonly NavigationManager _navigationManager;

        public VehicleService(HttpClient http,NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Vehicle> vehicles { get; set; } = new List<Vehicle>();
        

        public async Task CreateVehicle(Vehicle v)
        {
            var res = await _http.PostAsJsonAsync("api/ukraine", v);
            
            await SetVehicles(res);
        }

        public async Task DeleteVehicle(int id)
        {
            var res = await _http.DeleteAsync($"api/ukraine/{id}");
            await SetVehicles(res);
        }

        private async Task SetVehicles(HttpResponseMessage res)
        {
            var response = await res.Content.ReadFromJsonAsync<List<Vehicle>>();
            vehicles = response;
            _navigationManager.NavigateTo("vehicles");

        }

       
        public async Task<Vehicle> getSingleVehicle(int id)
        {

            var res = await _http.GetFromJsonAsync<Vehicle>($"api/ukraine/{id}");
            if (res != null)
                return res;
            throw new Exception("Vehicle not found");
        }

        public async Task GetVehicles()
        {

            var res = await _http.GetFromJsonAsync<List<Vehicle>>("api/ukraine");
            if (res != null) vehicles = res;
        }

        public async Task UpdateVehicle(Vehicle v)
        {
            var res = await _http.PutAsJsonAsync($"api/ukraine/{v.vehicleId}", v);
            await SetVehicles(res);
        }
    }

}
