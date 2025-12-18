using ConcertHub.Data;
using ConcertHub.Models;
using Microsoft.EntityFrameworkCore;

namespace ConcertHub.Repositories
{
    public class UserRepo : BaseRepository<User>, UserRepository
    {
        public UserRepo(DBApp context) : base(context)
        {
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _dbSet
                .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbSet
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task<IEnumerable<User>> GetUsersWithTicketsAsync()
        {
            return await _dbSet
                .Include(u => u.Tickets)
                .ThenInclude(t => t.Concert)
                .ThenInclude(c => c.Artist)
                .ToListAsync();
        }

        public async Task<User?> GetUserWithTicketsAsync(int id)
        {
            return await _dbSet
                .Include(u => u.Tickets)
                .ThenInclude(t => t.Concert)
                .ThenInclude(c => c.Artist)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<int> GetUserTicketCountAsync(int userId)
        {
            return await _context.Tickets
                .CountAsync(t => t.UserId == userId && t.IsPurchased);
        }

        public async Task<IEnumerable<User>> GetUsersRegisteredAfterDateAsync(DateTime date)
        {
            return await _dbSet
                .Where(u => u.RegistrationDate >= date)
                .OrderByDescending(u => u.RegistrationDate)
                .ToListAsync();
        }
    }
}