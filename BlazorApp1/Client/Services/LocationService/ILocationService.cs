namespace BlazorApp1.Client.Services.LocationService
{
    public interface ILocationService
    {

        List<Location> locations { get; set; }

        Task GetLocations();


        Task<Location> GetSingleLocation(int id);


        Task CreateLocation(Location l);
        Task UpdateLocation(Location l);

        Task DeleteLocation(int id);





    }
}
