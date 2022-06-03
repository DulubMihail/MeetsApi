using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MeetsApi.Models;

namespace MeetsApi.Controllers
{
    [Route("controller")]
    [ApiController]
    public class MeetController : ControllerBase
    {
        private readonly MeetContext _context;

        public MeetController(MeetContext context)
        {
            _context = context;
        }

    
        [HttpGet]
        public async Task<ActionResult<List<Meet>>> Get()
        {
            return Ok(await _context.Meets.ToListAsync());
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<List<Meet>>> Get(int id)
        {
            var meet = await _context.Meets.FindAsync(id);
            if (meet == null)
                return BadRequest("Dont choose meet");
            return Ok(meet);
        }

        [HttpPost]
        public async Task<ActionResult<List<Meet>>> AddMeet(Meet meet)
        {
            _context.Meets.Add(meet);
            await _context.SaveChangesAsync();

            return Ok(await _context.Meets.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Meet>>> UpdateMeet(Meet request)
        {
            var dbmeet = await _context.Meets.FindAsync(request.Id);
            if (dbmeet == null)
                return BadRequest("Dont Choose Meet");
            dbmeet.Name = request.Name;
            dbmeet.Description = request.Description;
            dbmeet.Plan = request.Plan;
            dbmeet.Organizer = request.Organizer;
            dbmeet.Time = request.Time;
            dbmeet.Place = request.Place;
            await _context.SaveChangesAsync();

            return Ok(await _context.Meets.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Meet>>> Delete(int id)
        {
            var dbmeet = await _context.Meets.FindAsync(id);
            if (dbmeet == null)
                return BadRequest("Dont Choose Meet");
            _context.Meets.Remove(dbmeet);
            await _context.SaveChangesAsync();

            return Ok(await _context.Meets.ToListAsync());

        }
    }
}
