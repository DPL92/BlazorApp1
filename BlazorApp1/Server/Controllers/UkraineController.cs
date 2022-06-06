using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Shared;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UkraineController : ControllerBase
    {
        private readonly DataContext _context;

        public UkraineController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Vehicle>>> GetVehicles() { 
            var vehicles = await _context.Vehicles.ToListAsync();
            return Ok(vehicles);
        
        }

        



        [HttpGet("{id}")]

        public async Task<ActionResult<Vehicle>> GetSingleVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.vehicleId == id);
            if (vehicle == null)
            {
                return NotFound("No vehicle with this id");
            }
            return Ok(vehicle);

        }



        [HttpPost]

        public async Task<ActionResult<List<Vehicle>>> CreateVehicle(Vehicle v)
        {
            _context.Vehicles.Add(v);
            await _context.SaveChangesAsync();
            return Ok(await GetDbVehicles());

        }

        private async Task<List<Vehicle>> GetDbVehicles() {
            return await _context.Vehicles.ToListAsync();
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<List<Vehicle>>> UpdateVehicle(Vehicle v, int id)
        {
            var dbVehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.vehicleId == id);
            if (dbVehicle == null) return NotFound("Kein Fahrzeug mit dieser Id");
            
            dbVehicle.manufacturer = v.manufacturer;
            dbVehicle.licensePlate = v.licensePlate;
            dbVehicle.seats = v.seats;
            dbVehicle.model = v.model;
            dbVehicle.requiredDL = v.requiredDL;

            await _context.SaveChangesAsync();
            return Ok(await GetDbVehicles());

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Vehicle>>> DeleteVehicle(int id)
        {
            var dbVehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.vehicleId == id);
            if (dbVehicle == null) return NotFound("Kein Fahrzeug mit dieser Id");

            _context.Vehicles.Remove(dbVehicle);
                    
            await _context.SaveChangesAsync();
            return Ok(await GetDbVehicles());

        }



    }
}
