using ConcertHub.Data;
using ConcertHub.Models;
using Microsoft.EntityFrameworkCore;

namespace ConcertHub.Repositories
{
    public class TicketRepo : BaseRepository<Ticket>, TicketRepository
    {
        public TicketRepo(DBApp context) : base(context)
        {
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByConcertAsync(int concertId)
        {
            return await _dbSet
                .Where(t => t.ConcertId == concertId)
                .Include(t => t.Concert)
                .Include(t => t.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByUserAsync(int userId)
        {
            return await _dbSet
                .Where(t => t.UserId == userId)
                .Include(t => t.Concert)
                .ThenInclude(c => c.Artist)
                .Include(t => t.Concert)
                .ThenInclude(c => c.Venue)
                .OrderByDescending(t => t.PurchaseDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetAvailableTicketsAsync()
        {
            return await _dbSet
                .Where(t => !t.IsPurchased)
                .Include(t => t.Concert)
                .ThenInclude(c => c.Artist)
                .Include(t => t.Concert)
                .ThenInclude(c => c.Venue)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetPurchasedTicketsAsync()
        {
            return await _dbSet
                .Where(t => t.IsPurchased)
                .Include(t => t.Concert)
                .ThenInclude(c => c.Artist)
                .Include(t => t.Concert)
                .ThenInclude(c => c.Venue)
                .Include(t => t.User)
                .OrderByDescending(t => t.PurchaseDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsWithDetailsAsync()
        {
            return await _dbSet
                .Include(t => t.Concert)
                .ThenInclude(c => c.Artist)
                .Include(t => t.Concert)
                .ThenInclude(c => c.Venue)
                .Include(t => t.User)
                .ToListAsync();
        }

        public async Task<Ticket?> GetTicketWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(t => t.Concert)
                .ThenInclude(c => c.Artist)
                .Include(t => t.Concert)
                .ThenInclude(c => c.Venue)
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<int> GetAvailableTicketsCountAsync(int concertId)
        {
            return await _dbSet
                .CountAsync(t => t.ConcertId == concertId && !t.IsPurchased);
        }

        public async Task<decimal> GetTotalRevenueByConcertAsync(int concertId)
        {
            return await _dbSet
                .Where(t => t.ConcertId == concertId && t.IsPurchased)
                .SumAsync(t => t.Price);
        }
    }
}
