using ConcertHub.Models;

namespace ConcertHub.Repositories
{
    public interface UserRepository : IRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetUsersWithTicketsAsync();
        Task<User?> GetUserWithTicketsAsync(int id);
        Task<int> GetUserTicketCountAsync(int userId);
        Task<IEnumerable<User>> GetUsersRegisteredAfterDateAsync(DateTime date);
    }
}