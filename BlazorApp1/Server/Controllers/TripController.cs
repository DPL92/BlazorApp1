using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Shared;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly DataContext _context;

        public TripController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Trip>>> GetTrips()
        {
            var trips = await _context.Trips.ToListAsync();
            return Ok(trips);

        }





        [HttpGet("{id}")]

        public async Task<ActionResult<Trip>> GetSingleTrip(int id)
        {
            var trip = await _context.Trips.FirstOrDefaultAsync(t => t.tripId == id);
            if (trip == null)
            {
                return NotFound("No trip with this id");
            }
            return Ok(trip);

        }



        [HttpPost]

        public async Task<ActionResult<List<Trip>>> CreateTrip(Trip t)
        {
            _context.Trips.Add(t);
            await _context.SaveChangesAsync();
            return Ok(await GetDbTrips());

        }

        private async Task<List<Trip>> GetDbTrips()
        {
            return await _context.Trips.ToListAsync();
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<List<Trip>>> UpdateTrip(Trip t, int id)
        {
            var dbTrip = await _context.Trips.FirstOrDefaultAsync(t=> t.tripId == id);
            if (dbTrip == null) return NotFound("Kein Trip mit dieser Id");

            dbTrip.vehicle = t.vehicle;
            dbTrip.endL = t.endL;
            dbTrip.startL = t.startL;
            dbTrip.endId = t.endId;
            dbTrip.startId = t.startId;
            dbTrip.duration = t.duration;
            dbTrip.date = t.date;
            dbTrip.driver = t.driver;
            dbTrip.vehicleId = t.vehicleId;
            dbTrip.finished = t.finished;

            await _context.SaveChangesAsync();
            return Ok(await GetDbTrips());

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Trip>>> DeleteTrip(int id)
        {
            var dbTrip= await _context.Trips.FirstOrDefaultAsync(t => t.tripId == id);
            if (dbTrip == null) return NotFound("Kein Trip mit dieser Id");

            _context.Trips.Remove(dbTrip);

            await _context.SaveChangesAsync();
            return Ok(await GetDbTrips());

        }



    }
}
