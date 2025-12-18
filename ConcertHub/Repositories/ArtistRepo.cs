using ConcertHub.Data;
using ConcertHub.Models;
using Microsoft.EntityFrameworkCore;

namespace ConcertHub.Repositories
{
    public class ArtistRepo : BaseRepository<Artist>, ArtistRepository
    {
        public ArtistRepo(DBApp context) : base(context)
        {
        }

        public async Task<IEnumerable<Artist>> GetByGenreAsync(string genre)
        {
            return await _dbSet
                .Where(a => a.Genre != null && a.Genre.ToLower().Contains(genre.ToLower()))
                .ToListAsync();
        }

        public async Task<IEnumerable<Artist>> GetByCountryAsync(string country)
        {
            return await _dbSet
                .Where(a => a.Country != null && a.Country.ToLower().Contains(country.ToLower()))
                .ToListAsync();
        }

        public async Task<IEnumerable<Artist>> GetArtistsWithConcertsAsync()
        {
            return await _dbSet
                .Include(a => a.Concerts)
                .ThenInclude(c => c.Venue)
                .ToListAsync();
        }

        public async Task<Artist?> GetArtistWithConcertsAsync(int id)
        {
            return await _dbSet
                .Include(a => a.Concerts)
                .ThenInclude(c => c.Venue)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
