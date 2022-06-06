using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorApp1.Client.Services.DriverService
{
    
        public class DriverService: IDriverService
        {
            private readonly HttpClient _http;

            private readonly NavigationManager _navigationManager;

            public DriverService(HttpClient http, NavigationManager navigationManager)
            {
                _http = http;
                _navigationManager = navigationManager;
            }

            
            public List<Driver> drivers { get; set; } = new List<Driver>();

            public async Task CreateDriver(Driver d)
            {
                var res = await _http.PostAsJsonAsync("api/driver", d);

                await SetDrivers(res);
            }

            public async Task DeleteDriver(int id)
            {
                var res = await _http.DeleteAsync($"api/driver/{id}");
                await SetDrivers(res);
            }

            private async Task SetDrivers(HttpResponseMessage res)
            {
                var response = await res.Content.ReadFromJsonAsync<List<Driver>>();
                drivers = response;
                _navigationManager.NavigateTo("drivers");

            }


            public async Task<Driver> GetSingleDriver(int id)
            {

                var res = await _http.GetFromJsonAsync<Driver>($"api/driver/{id}");
                if (res != null)
                    return res;
                throw new Exception("Driver not found");
            }

            public async Task GetDrivers()
            {

                var res = await _http.GetFromJsonAsync<List<Driver>>("api/driver");
                if (res != null) drivers = res;
            }

            public async Task UpdateDriver(Driver d)
            {
                var res = await _http.PutAsJsonAsync($"api/driver/{d.driverId}", d);
                await SetDrivers(res);
            }
        }









 }

