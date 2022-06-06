namespace BlazorApp1.Client.Services.DriverService
{
    public interface IDriverService
    {
        
        List<Driver> drivers { get; set; }

        Task GetDrivers();
       

        Task<Driver> GetSingleDriver(int id);
       

        Task CreateDriver(Driver d);
        Task UpdateDriver(Driver d);

        Task DeleteDriver(int id);

    }
}
