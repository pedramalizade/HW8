using HW_week_8.DataBase;
using HW_week_8.Entities;
using HW_week_8.Enums;
using HW_week_8.Repositorys;
using HW_week_8.Services;
using System;

Console.WriteLine("Welcome.");
SeedData.Seed();

MainMenu();

void EntekhabVahedManu()
{
    if (InMemoryDB.CurrentUser == null || InMemoryDB.CurrentUser is not Student)
    {
        Console.WriteLine("Please Login. ");
        Console.WriteLine("Press Any Key to Continiue.");
        Console.ReadLine();
        Login();
    }
    Console.Clear();
    Console.WriteLine("**********************");
    Console.WriteLine("       ENTEKHAB VAHED MENU       ");
    Console.WriteLine("**********************");

    Console.WriteLine("********** SELECTED COURSES *********");
    UserServices userSer = new UserServices();
    Student currentUser = (Student)userSer.GetCurrentUser();

    foreach (var item in currentUser.Courses)
    {
        Console.WriteLine(item);
    }
    Console.WriteLine("********** SELECTED COURSES *********");

    Console.WriteLine("********** ACCESSIBLE COURSES *********");
    CourseService courseService = new CourseService();
    var course = courseService.GetCourses();
    foreach (var item2 in course)
    {
        Console.WriteLine(item2);
    }
    Console.WriteLine("********** ACCESSIBLE COURSES *********");
    Console.Write("Please Select Your Action Select your Course : ");

    var selectedCourse = Int32.Parse(Console.ReadLine());
    foreach (var item in InMemoryDB.Courses)
    {
        if(item.Id == selectedCourse)
        {
            currentUser.Courses.Add(item);
        }
    }
    EntekhabVahedManu();
  

}
void TeacherManu()
{
    if (InMemoryDB.CurrentUser == null)
    {
        Console.WriteLine("Please Login. ");
        Console.WriteLine("Press Any Key to Continiue.");
        Console.ReadLine();
        Login();
    }
    if (InMemoryDB.CurrentUser == null && InMemoryDB.CurrentUser is not Teacher)
    {
        Console.WriteLine("Access Denid. ");
        Console.WriteLine("Press Any Key to Continiue.");
        Console.ReadLine();
        Login();
    }
    Console.Clear();
    Console.WriteLine("**********************");
    Console.WriteLine("       TEACHER MENU       ");
    Console.WriteLine("**********************");
    Console.Write("Please Select Your Action (1: ChaangePass, 2: Entekhab vhed, 3: Logout) : ");
    if (!Int32.TryParse(Console.ReadLine(), out int actionId))
    {
        Console.WriteLine("Selected Action is Invalid ");
        StudentManu();
    }
}
void StudentManu()
{
    if (InMemoryDB.CurrentUser == null || InMemoryDB.CurrentUser is not Student)
    {
        Console.WriteLine("Please Login. ");
        Console.WriteLine("Press Any Key to Continiue.");
        Console.ReadLine();
        Login();
    }
    Console.Clear();
    Console.WriteLine("**********************");
    Console.WriteLine("       STUDENT MENU       ");
    Console.WriteLine("**********************");
    Console.Write("Please Select Your Action (1: ChaangePass, 2: Entekhab vhed, 3: Logout) : ");
    if (!Int32.TryParse(Console.ReadLine(), out int actionId))
    {
        Console.WriteLine("Selected Action is Invalid ");
        StudentManu();
    }

    switch (actionId)
    {
        case 1:
            Console.Write("Please Enter Your Current Password: ");
            var currentPass = Console.ReadLine();
            Console.Write("Please Enter Your New Password: ");
            var newPass = Console.ReadLine();
            Student st = (Student)InMemoryDB.CurrentUser;
            var result = st.ChangePassword(currentPass, newPass);
            Console.WriteLine(result.Message);
            Console.WriteLine("Press Any Key to Continiue.");
            Console.ReadLine();
            StudentManu();
            break;
        case 2:
            EntekhabVahedManu();
            break;
        case 3:
            InMemoryDB.CurrentUser = null;
            MainMenu();
            break;
        default:
            break;
    }
}
void MainMenu()
{
    Console.Clear();
    Console.WriteLine("**********************");
    Console.WriteLine("       MAIN MENU       ");
    Console.WriteLine("**********************");
    Console.Write("Please Select Your Action (1: Register, 2: Login) : ");
    if (!Int32.TryParse(Console.ReadLine(), out int actionId))
    {
        Console.WriteLine("Selected Action is Invalid ");
        MainMenu();
    }
    switch (actionId)
    {
        case 1:
            Register(null);
            break;
        case 2:
            Login();
            break;
        default:
            Console.WriteLine("Selected Action is Invalid ");
            MainMenu();
            break;
    }

}
void OperatorMenu()
{
    if (InMemoryDB.CurrentUser == null || InMemoryDB.CurrentUser is not Operator)
    {
        Console.WriteLine("Please Login. ");
        Console.WriteLine("Press Any Key to Continiue.");
        Console.ReadLine();
        Login();
    }

    Console.Clear();
    Console.WriteLine("**********************");
    Console.WriteLine("       Operator MENU       ");
    Console.WriteLine("**********************");
    Console.Write("Please Select Your Action (1: ChaangePass, 2:  Activate Users, 3: Add Course , 4: Logout) : ");
    if (!Int32.TryParse(Console.ReadLine(), out int actionId))
    {
        Console.WriteLine("Selected Action is Invalid ");
        StudentManu();
    }

    switch (actionId)
    {
        case 1:
           
            Console.Write("Please Enter Your Current Password: ");
            var currentPass = Console.ReadLine();
            Console.Write("Please Enter Your New Password: ");
            var newPass = Console.ReadLine();
            Student op = (Student)InMemoryDB.CurrentUser;
            var result = op.ChangePassword(currentPass, newPass);
            Console.WriteLine(result.Message);
            Console.WriteLine("Press Any Key to Continiue.");
            Console.ReadLine();
            OperatorMenu();
            break;
        case 2:
            break;
        case 3:
            Console.Write("Please Enter Your Current Id: ");
            var currentId = Int32.Parse(Console.ReadLine());
            Console.Write("Please Enter CourseName: ");
            var courseName = Console.ReadLine();
            Console.Write("Please Enter Course Unit ");
            var corseUnit = Int32.Parse(Console.ReadLine());

            Course course = new Course();
            course.Id = currentId;
            course.Name = courseName;
            course.Unit = corseUnit;
            
            CourseService courseServise = new CourseService();
            courseServise.SetCourse(course);
            OperatorMenu();
            break;
        case 4:
            InMemoryDB.CurrentUser = null;
            MainMenu();
            break;
        default:
            break;
    }
}
void Login()
{
    Console.Clear();
    Console.WriteLine("**********************");
    Console.WriteLine("       lOGIN          ");
    Console.WriteLine("**********************");
    Console.Write("Please Select Your Role (1: Student, 2: Operator, 3: Teacher) : ");

    if (!Int32.TryParse(Console.ReadLine(), out int roleId))
    {
        Console.WriteLine("Selected Role is Invalid ");
        Login();
    }
    RoleEnum role = (RoleEnum)roleId;
    Console.Write("Please Enter Username: ");
    var userName = Console.ReadLine();

    Console.Write("Please Enter Password: ");
    var password = Console.ReadLine();

    UserServices userServices = new UserServices();
    var result = userServices.Login(userName, password);
    if (!result.IsSucces)
    {
        Console.WriteLine(result.Message);
        Console.WriteLine("Press Any Key to Continiue.");
        Console.ReadLine();
        Login();
    }

    switch (role)
    {
        case RoleEnum.Student:
            StudentManu();
            break;
        case RoleEnum.Operator:
            OperatorMenu();
            break;
        case RoleEnum.Teacher:
            TeacherManu();
            break;
        default:
            break;
    }


}
void Register(string? message)
{
    Console.Clear();
    if (message != null)
    {
        Console.WriteLine(message);
    }
    Console.WriteLine("**********************");
    Console.WriteLine("       REGISTER          ");
    Console.WriteLine("**********************");
    Console.Write("Please Select Your Role (1: Student, 2: Operator, 3: Teacher) : ");

    if (!Int32.TryParse(Console.ReadLine(), out int roleId))
    {
        Console.WriteLine("Selected Role is Invalid ");
        Register(null);
    }

    RoleEnum role = (RoleEnum)roleId;
    Console.Write("Please Enter FirstName: ");
    var firstName = Console.ReadLine();

    Console.Write("Please Enter lastName: ");
    var lastName = Console.ReadLine();

    Console.Write("Please Enter Email: ");
    var email = Console.ReadLine();

    Console.Write("Please Enter Password: ");
    var password = Console.ReadLine();

    UserServices userServices = new UserServices();
    User user;
    switch (role) 
    {
        case RoleEnum.Student:
            user = new Student(firstName, lastName, email);
            break;
        case RoleEnum.Operator:
            user= new Operator(firstName, lastName, email);
            break;
        case RoleEnum.Teacher:
            user = new Teacher(firstName, lastName, email);
            break;
        default:
            user = new User(firstName, lastName, email);
            break;
    }

    var result = userServices.Register(user, password);
    if (!result.IsSucces)
    {
        Console.WriteLine(result.Message);
        Console.Write("Press Any Key to Continue.");
        Console.ReadLine();
        //Register();
    }
    else
    {
        Console.WriteLine("Registered is Success. ");
        Console.Write("Press Any Key to Continue.");
        Console.ReadLine();
        Login();
    }
}