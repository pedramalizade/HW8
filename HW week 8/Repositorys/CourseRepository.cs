using HW_week_8.Contract;
using HW_week_8.DataBase;
using HW_week_8.Entities;

namespace HW_week_8.Repositorys
{
    public class CourseRepository : ICourseRepository
    {
        public void AddCourse(Course course)
        {
            InMemoryDB.Courses.Add(course);
        }

        public List<Course> GetCourses()
        {
            return InMemoryDB.Courses;
        }
    }
}
