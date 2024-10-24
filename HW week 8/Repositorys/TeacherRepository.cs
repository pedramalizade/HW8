using HW_week_8.Contract;
using HW_week_8.DataBase;
using HW_week_8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_week_8.Repositorys
{
    public class TeacherRepository : ITeacherRepository
    {
        public Teacher GetTeacher()
        {
            foreach (var user in InMemoryDB.Users)
            {
                if(user is Teacher)
                {
                    return (Teacher)user;   
                }
            }
            return new Teacher("Test", "Test", "Test");
        }
    }
}
