using Domain;
using Domain.RepositoryPattern;

namespace Infrastructure.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>();

        public async Task AddUserAsync(User user, CancellationToken cancellationToken)
        {
            users.Add(user);
        }

        public async Task RemoveUserAsync(User user, CancellationToken cancellationToken)
        {
            users.Remove(user);
        }

        public async Task<List<User>> GetAllUserAsync(CancellationToken cancellationToken)
        {
            return users;
        }

        public async Task<User> GetUserByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }

       
    }
}
