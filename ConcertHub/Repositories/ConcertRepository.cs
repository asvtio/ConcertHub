using ConcertHub.Models;

namespace ConcertHub.Repositories
{
    public interface ConcertRepository : IRepository<Concert>
    {
        Task<IEnumerable<Concert>> GetUpcomingConcertsAsync();
        Task<IEnumerable<Concert>> GetPastConcertsAsync();
        Task<IEnumerable<Concert>> GetConcertsByArtistAsync(int artistId);
        Task<IEnumerable<Concert>> GetConcertsByVenueAsync(int venueId);
        Task<IEnumerable<Concert>> GetConcertsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Concert>> GetConcertsWithDetailsAsync();
        Task<Concert?> GetConcertWithDetailsAsync(int id);
    }
}
