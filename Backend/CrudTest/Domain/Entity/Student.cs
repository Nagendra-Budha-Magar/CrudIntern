namespace CrudTest.Domain.Entity
{
    public class Student
    {
        public int Id { get; set; }
        public string? StudentName { get; set; }
        public int Grade { get; set; }
        public string? PhoneNo { get; set; }
        public int RollNo { get; set; }

        public int SemesterId { get; set; }
        public Semester? Semester { get; set; }
    }
}
