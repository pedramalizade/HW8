using HW_week_8.Entities;

namespace HW_week_8.DataBase
{
    public static class InMemoryDB
    {
        public static User? CurrentUser { get; set; }
        public static List<User> Users { get; set; } = new List<User>();
        public static List<Course> Courses { get; set; } = new List<Course>();

    }
}
