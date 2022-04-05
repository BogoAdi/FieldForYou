using Domain;
using Domain.RepositoryPattern;

namespace Infrastructure.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>();

        public void AddAppointment(Appointment appointment, User user)
        {
            user.Appointments.Add(appointment);
        }

        public void AddUser(User user)
        {

            users.Add(user);
        }

        public User GetUser(string name)
        {
            var found = users.Find(x =>x.Username == name);
            if (found != null) return found;
            return null;
        }

        public void RemoveUser(User user)
        {
            users.Remove(user);
        }

        public void ShowAll()
        {
            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
            }
        }
    }
}
