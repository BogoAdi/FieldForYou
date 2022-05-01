using Domain;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>();
        private readonly FieldForYouContext _context;

        public UserRepository(FieldForYouContext context)
        {
            _context = context;
        }

        public async Task<User> AddUserAsync(User user, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> RemoveUserAsync(Guid id, CancellationToken cancellationToken)
        {
            var userToBeDeleted = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (userToBeDeleted == null) { return null; }

            _context.Users.Remove(userToBeDeleted);
            await _context.SaveChangesAsync();

            return userToBeDeleted;
        }

        public async Task<List<User>> GetAllUserAsync(CancellationToken cancellationToken)
        {
            return await _context.Users.Include(x => x.Appointments).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var found = await _context.Users.Include(x => x.Appointments).FirstOrDefaultAsync(x => x.Id == id);
            if (found == null) { return null; }
            return found;
        }

        public async Task<User> UpdateUserASync(Guid id, User user, CancellationToken cancellationToken)
        {
            var found = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (found == null) { return null; }

            found.Username = user.Username;
            found.Password = user.Password;
            found.Email = user.Email;
            found.PhoneNumber = user.PhoneNumber;
            found.Name = user.Name;

            await _context.SaveChangesAsync();

            return found;
        }
    }
}
