using HW_week_8.Contract;
using HW_week_8.DataBase;
using HW_week_8.Entities;

namespace HW_week_8.Repositorys
{
    public class UserRepository : IUserRepository
    {
        public User GetCurrentUser()
        {
            return InMemoryDB.CurrentUser ?? new User("test", "test", "test");
        }

        public List<User> GetUsers()
        {
            return InMemoryDB.Users;
        }

        public void Login(User user)
        {
            InMemoryDB.CurrentUser = user;
        }

        public void Register(User user)
        {
            InMemoryDB.Users.Add(user); 
        }
    }
}
