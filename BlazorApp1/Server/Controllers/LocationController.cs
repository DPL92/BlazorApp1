using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly DataContext _context;

        public LocationController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Location>>> GetLocations()
        {
            var locations = await _context.Locations.ToListAsync();
            return Ok(locations);

        }





        [HttpGet("{id}")]

        public async Task<ActionResult<Driver>> GetSingleLocation(int id)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(l => l.locationId == id);
            if (location == null)
            {
                return NotFound("No location with this id");
            }
            return Ok(location);

        }



        [HttpPost]

        public async Task<ActionResult<List<Location>>> CreateLocation(Location l)
        {
            _context.Locations.Add(l);
            await _context.SaveChangesAsync();
            return Ok(await GetDbLocations());

        }

        private async Task<List<Location>> GetDbLocations()
        {
            return await _context.Locations.ToListAsync();
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<List<Location>>> UpdateLocation(Location l, int id)
        {
            var dbLocation = await _context.Locations.FirstOrDefaultAsync(l => l.locationId == id);
            if (dbLocation == null) return NotFound("Kein Ort mit dieser Id");

            dbLocation.locationName = l.locationName;
            dbLocation.country = l.country;
            dbLocation.postalCode = l.postalCode;
            dbLocation.street = l.street;
            dbLocation.houseNr = l.houseNr;
            

            await _context.SaveChangesAsync();
            return Ok(await GetDbLocations());

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Location>>> DeleteLocation(int id)
        {
            var dbLocation = await _context.Locations.FirstOrDefaultAsync(l => l.locationId == id);
            if (dbLocation == null) return NotFound("Kein Ort mit dieser Id");

            _context.Locations.Remove(dbLocation);

            await _context.SaveChangesAsync();
            return Ok(await GetDbLocations());

        }


















    }
}
