using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Server.Controllers
{
    

        [Route("api/[controller]")]
        [ApiController]
        public class DriverController : ControllerBase
        {
            private readonly DataContext _context;

            public DriverController(DataContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<List<Driver>>> GetDrivers()
            {
                var drivers = await _context.Drivers.ToListAsync();
                return Ok(drivers);

            }

         



            [HttpGet("{id}")]

            public async Task<ActionResult<Driver>> GetSingleDriver(int id)
            {
                var driver = await _context.Drivers.FirstOrDefaultAsync(d => d.driverId == id);
                if (driver == null)
                {
                    return NotFound("No driver with this id");
                }
                return Ok(driver);

            }



            [HttpPost]

            public async Task<ActionResult<List<Driver>>> CreateDriver(Driver d)
            {
                _context.Drivers.Add(d);
                await _context.SaveChangesAsync();
                return Ok(await GetDbDrivers());

            }

            private async Task<List<Driver>> GetDbDrivers()
            {
                return await _context.Drivers.ToListAsync();
            }

            [HttpPut("{id}")]

            public async Task<ActionResult<List<Driver>>> UpdateDriver(Driver d, int id)
            {
                var dbDriver = await _context.Drivers.FirstOrDefaultAsync(d => d.driverId == id);
                if (dbDriver == null) return NotFound("Kein Fahrer mit dieser Id");

                dbDriver.driverFirstName = d.driverFirstName;
                dbDriver.driverLastName = d.driverLastName;
                dbDriver.license = d.license;

                await _context.SaveChangesAsync();
                return Ok(await GetDbDrivers());

            }

            [HttpDelete("{id}")]

            public async Task<ActionResult<List<Driver>>> DeleteDriver(int id)
            {
                var dbDriver= await _context.Drivers.FirstOrDefaultAsync(d => d.driverId == id);
                if (dbDriver == null) return NotFound("Kein Fahrer mit dieser Id");

                _context.Drivers.Remove(dbDriver);

                await _context.SaveChangesAsync();
                return Ok(await GetDbDrivers());

            }



        }














}
