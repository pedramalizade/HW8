using HW_week_8.Entities;

namespace HW_week_8.Contract
{
    public interface ICourseRepository
    {
        void AddCourse(Course course);
        List<Course> GetCourses();

    }
}
