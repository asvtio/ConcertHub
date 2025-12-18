using ConcertHub.Models;

namespace ConcertHub.Repositories
{
    public interface ArtistRepository : IRepository<Artist>
    {
        Task<IEnumerable<Artist>> GetByGenreAsync(string genre);
        Task<IEnumerable<Artist>> GetByCountryAsync(string country);
        Task<IEnumerable<Artist>> GetArtistsWithConcertsAsync();
        Task<Artist?> GetArtistWithConcertsAsync(int id);
    }
}
