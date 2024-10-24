using HW_week_8.Contract;
using HW_week_8.DataBase;
using HW_week_8.Entities;
using HW_week_8.Repositorys;
using System.Security.AccessControl;

namespace HW_week_8.Services
{
    public class UserServices
    {
        IUserRepository userRep;
        public UserServices()
        {
            userRep = new UserRepository();
        }
        public Result Login(string userName, string password)
        {
            IUserRepository userRep = new UserRepository();   
            var users = userRep.GetUsers();
            foreach (var user in InMemoryDB.Users)
            {
                if (user.UserName == userName)
                {
                    var res = user.CheckPassword(password);
                    if (res.IsSucces)
                    {
                        if (user.IsActive)
                        {
                            userRep.Login(user);
                            return new Result(true);
                        }
                        else
                        {
                            return new Result(false, "User is InActive");
                        }

                    }
                    else
                    {
                        return new Result(false, "Password Is Invalid");
                    }
                }
            }
            return new Result(false, "User Not Found. ");
        }
        public Result Register(User user, string pass)
        {
            var result = user.SetPassword(pass);
            if (result.IsSucces)
            {
                userRep.Register(user);
                return new Result(true);
            }
            else
            {
                return new Result(false, result.Message);
            }
        }

        public User GetCurrentUser()
        {
            return userRep.GetCurrentUser();
        }
    }
}
