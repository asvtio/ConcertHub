using ConcertHub.Data;
using ConcertHub.Models;
using Microsoft.EntityFrameworkCore;

namespace ConcertHub.Repositories
{
    public class VenueRepo : BaseRepository<Venue>, VenueRepository
    {
        public VenueRepo(DBApp context) : base(context)
        {
        }

        public async Task<IEnumerable<Venue>> GetByCapacityRangeAsync(int minCapacity, int maxCapacity)
        {
            return await _dbSet
                .Where(v => v.Capacity >= minCapacity && v.Capacity <= maxCapacity)
                .ToListAsync();
        }

        public async Task<IEnumerable<Venue>> GetVenuesWithConcertsAsync()
        {
            return await _dbSet
                .Include(v => v.Concerts)
                .ThenInclude(c => c.Artist)
                .ToListAsync();
        }

        public async Task<Venue?> GetVenueWithConcertsAsync(int id)
        {
            return await _dbSet
                .Include(v => v.Concerts)
                .ThenInclude(c => c.Artist)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<Venue>> GetByLocationKeywordAsync(string keyword)
        {
            return await _dbSet
                .Where(v => v.Address != null && v.Address.ToLower().Contains(keyword.ToLower()) ||
                           v.Name.ToLower().Contains(keyword.ToLower()))
                .ToListAsync();
        }
    }
}