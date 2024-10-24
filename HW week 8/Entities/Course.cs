namespace HW_week_8.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Unit { get; set; }
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

        public override string ToString()
        {
            return $"{Id} - {Name}({Unit} - {Teacher.FirstName} {Teacher.LastName})";
        }
    }
}
