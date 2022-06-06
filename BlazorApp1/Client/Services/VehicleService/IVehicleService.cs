namespace BlazorApp1.Client.Services.VehicleService
{
    public interface IVehicleService
    {
        List<Vehicle> vehicles { get; set; }
        

     
        Task GetVehicles();

       
        Task<Vehicle> getSingleVehicle(int id);

        Task CreateVehicle(Vehicle v);
        Task UpdateVehicle(Vehicle v);

        Task DeleteVehicle(int id);

    }
}
