using ConcertHub.Data;
using ConcertHub.Models;
using Microsoft.EntityFrameworkCore;

namespace ConcertHub.Repositories
{
    public class ConcertRepo : BaseRepository<Concert>, ConcertRepository
    {
        public ConcertRepo(DBApp context) : base(context)
        {
        }

        public async Task<IEnumerable<Concert>> GetUpcomingConcertsAsync()
        {
            return await _dbSet
                .Where(c => c.DateTime > DateTime.Now)
                .Include(c => c.Artist)
                .Include(c => c.Venue)
                .OrderBy(c => c.DateTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<Concert>> GetPastConcertsAsync()
        {
            return await _dbSet
                .Where(c => c.DateTime <= DateTime.Now)
                .Include(c => c.Artist)
                .Include(c => c.Venue)
                .OrderByDescending(c => c.DateTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<Concert>> GetConcertsByArtistAsync(int artistId)
        {
            return await _dbSet
                .Where(c => c.ArtistId == artistId)
                .Include(c => c.Venue)
                .OrderBy(c => c.DateTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<Concert>> GetConcertsByVenueAsync(int venueId)
        {
            return await _dbSet
                .Where(c => c.VenueId == venueId)
                .Include(c => c.Artist)
                .OrderBy(c => c.DateTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<Concert>> GetConcertsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(c => c.DateTime >= startDate && c.DateTime <= endDate)
                .Include(c => c.Artist)
                .Include(c => c.Venue)
                .OrderBy(c => c.DateTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<Concert>> GetConcertsWithDetailsAsync()
        {
            return await _dbSet
                .Include(c => c.Artist)
                .Include(c => c.Venue)
                .Include(c => c.Tickets)
                .ToListAsync();
        }

        public async Task<Concert?> GetConcertWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(c => c.Artist)
                .Include(c => c.Venue)
                .Include(c => c.Tickets)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
