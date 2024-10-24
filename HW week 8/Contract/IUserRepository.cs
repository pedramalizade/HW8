using HW_week_8.Entities;

namespace HW_week_8.Contract
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        void Login(User user);
        void Register (User user);

        User GetCurrentUser();
    }
}
