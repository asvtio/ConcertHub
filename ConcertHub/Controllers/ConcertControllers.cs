using ConcertHub.Models;
using ConcertHub.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ConcertHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConcertsControllers : ControllerBase  
    {
        private readonly ConcertRepository _concertRepository;
        private readonly ArtistRepository _artistRepository;
        private readonly VenueRepository _venueRepository;

        public ConcertsControllers(
            ConcertRepository concertRepository,
            ArtistRepository artistRepository,
            VenueRepository venueRepository)
        {
            _concertRepository = concertRepository;
            _artistRepository = artistRepository;
            _venueRepository = venueRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Concert>>> GetConcerts()
        {
            var concerts = await _concertRepository.GetAllAsync();
            return Ok(concerts);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Concert>> GetConcert(int id)
        {
            var concert = await _concertRepository.GetByIdAsync(id);

            if (concert == null)
            {
                return NotFound();
            }
            concert.Artist = await _artistRepository.GetByIdAsync(concert.ArtistId);
            concert.Venue = await _venueRepository.GetByIdAsync(concert.VenueId);

            return concert;
        }
        [HttpPost]
        public async Task<ActionResult<Concert>> PostConcert(Concert concert)
        {
            await _concertRepository.AddAsync(concert);
            return CreatedAtAction(nameof(GetConcert), new { id = concert.Id }, concert);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConcert(int id, Concert concert)
        {
            if (id != concert.Id)
            {
                return BadRequest();
            }

            await _concertRepository.UpdateAsync(concert);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConcert(int id)
        {
            await _concertRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}