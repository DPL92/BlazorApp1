namespace BlazorApp1.Client.Services.TripService
{
    public interface ITripService
    {
        List<Trip> trips { get; set; }
        

     
        Task GetTrips();

       
        Task<Trip> GetSingleTrip(int id);

        Task CreateTrip(Trip t);
        Task UpdateTrip(Trip t);

        Task DeleteTrip(int id);

    }
}
