using HW_week_8.Contract;
using HW_week_8.Entities;
using HW_week_8.Repositorys;

namespace HW_week_8.Services
{
    public class CourseService
    {
        ICourseRepository courseRepo;
        ITeacherRepository teacherRepo;
        public CourseService()
        {
            courseRepo = new CourseRepository();
            teacherRepo = new TeacherRepository();
        }
        public void SetCourse(Course course)
        {
            course.Teacher = teacherRepo.GetTeacher();
            courseRepo.AddCourse(course);
        }

        public List<Course> GetCourses()
        {
            return courseRepo.GetCourses();
        }
    }
}
