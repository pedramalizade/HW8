using HW_week_8.Contract;
using HW_week_8.DataBase;
using HW_week_8.Entities;

namespace HW_week_8.Repositorys
{
    internal class UserRepositoryFile : IUserRepository
    {
        public User GetCurrentUser()
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void Login(User user)
        {
            throw new NotImplementedException();
        }

        public void Register(User user)
        {
           InMemoryDB.Users.Add(user);
        }
    }
}
