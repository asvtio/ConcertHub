using ConcertHub.Models;

namespace ConcertHub.Repositories
{
    public interface TicketRepository : IRepository<Ticket>
    {
        Task<IEnumerable<Ticket>> GetTicketsByConcertAsync(int concertId);
        Task<IEnumerable<Ticket>> GetTicketsByUserAsync(int userId);
        Task<IEnumerable<Ticket>> GetAvailableTicketsAsync();
        Task<IEnumerable<Ticket>> GetPurchasedTicketsAsync();
        Task<IEnumerable<Ticket>> GetTicketsWithDetailsAsync();
        Task<Ticket?> GetTicketWithDetailsAsync(int id);
        Task<int> GetAvailableTicketsCountAsync(int concertId);
        Task<decimal> GetTotalRevenueByConcertAsync(int concertId);
    }
}
