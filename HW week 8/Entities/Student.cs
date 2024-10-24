using HW_week_8.Enums;
using System.Reflection.Metadata.Ecma335;

namespace HW_week_8.Entities
{
    public class Student : User
    {
        public int StudentNO { get; private set; }
        public int Age { get; set; }
        public StudentStatusEnum Status { get; private set; }
        public GenderEnum Gender { get; set; }
        public bool IsMashrot { get; private set; }
        public bool IsMomtazrty { get; private set; }
        public List<Course> Courses { get; set; } = new List<Course>();
        public Student(string firstName, string lastName, string email) : base(firstName, lastName, email)
        {
            Status = StudentStatusEnum.Inactive;
        }
        public Student(string firstName, string lastName, string email, int studentNO, GenderEnum gender, int age) : this(firstName, lastName, email)
        {
            StudentNO = studentNO;
            Gender = gender;
            Age = age;
        }

        public override Result SetPassword(string pass) // chra result? 
        {
            if (!string.IsNullOrEmpty(pass) && pass.Length >= 6)
            {
                Password = pass;
                return new Result(true, null);
            }
            else
            {
                return new Result(false, "Password is Incorrect");
            }
        }
        public override Result ChangePassword(string currentPass, string newPass)
        {
            if (currentPass == Password)
            {
                return SetPassword(newPass);
            }
            else
            {
                return new Result(false, "Current Pass Is InCorrect.");
            }
        }

        public string Activate()
        {
            if (Status == StudentStatusEnum.Actice)
            {
                return "student already active";
            }
            if (Status == StudentStatusEnum.Suspend)
            {
                return "Can not active student";
            }
            Status = StudentStatusEnum.Actice;
            return "Student Active successfilly";
        }

        public string SetMashrot()
        {
            IsMashrot = true;
            return "Success";
        }
        public string SetMomtaz()
        {
            IsMomtazrty = true;
            return "Success";
        }
    }
}
