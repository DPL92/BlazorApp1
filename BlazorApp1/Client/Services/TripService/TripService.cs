using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
namespace BlazorApp1.Client.Services.TripService
{
    public class TripService : ITripService
    {
        private readonly HttpClient _http;

        private readonly NavigationManager _navigationManager;

        public TripService(HttpClient http,NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Trip> trips { get; set; } = new List<Trip>();
        

        public async Task CreateTrip(Trip t)
        {
            var res = await _http.PostAsJsonAsync("api/trip", t);
            
            await SetTrips(res);
        }

        public async Task DeleteTrip(int id)
        {
            var res = await _http.DeleteAsync($"api/trip/{id}");
            await SetTrips(res);
        }

        private async Task SetTrips(HttpResponseMessage res)
        {
            var response = await res.Content.ReadFromJsonAsync<List<Trip>>();
            trips = response;
            _navigationManager.NavigateTo("trips");

        }

       
        public async Task<Trip> getSingleTrip(int id)
        {

            var res = await _http.GetFromJsonAsync<Trip>($"api/trip/{id}");
            if (res != null)
                return res;
            throw new Exception("Vehicle not found");
        }

        public async Task GetTrips()
        {

            var res = await _http.GetFromJsonAsync<List<Trip>>("api/trip");
            if (res != null) trips = res;
        }

        public async Task UpdateTrip(Trip t)
        {
            var res = await _http.PutAsJsonAsync($"api/ukraine/{t.tripId}", t);
            await SetTrips(res);
        }
    }

}
