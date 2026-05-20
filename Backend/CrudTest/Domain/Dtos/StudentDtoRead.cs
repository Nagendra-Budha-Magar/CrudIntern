namespace CrudTest.Domain.Dtos
{
    public class StudentDtoRead
    {
        public string? StudentName { get; set; }
        public int Grade { get; set; }
        public string? PhoneNo { get; set; }
        public int RollNo { get; set; }
        public SemesterDtoRead? Semester { get; set; }
    }
}
