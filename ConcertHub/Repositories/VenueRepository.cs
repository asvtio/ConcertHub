using ConcertHub.Models;

namespace ConcertHub.Repositories
{
    public interface VenueRepository : IRepository<Venue>
    {
        Task<IEnumerable<Venue>> GetByCapacityRangeAsync(int minCapacity, int maxCapacity);
        Task<IEnumerable<Venue>> GetVenuesWithConcertsAsync();
        Task<Venue?> GetVenueWithConcertsAsync(int id);
        Task<IEnumerable<Venue>> GetByLocationKeywordAsync(string keyword);
    }
}
