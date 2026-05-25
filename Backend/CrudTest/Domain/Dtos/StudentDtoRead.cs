namespace CrudTest.Domain.Dtos
{
    public class StudentDtoRead
    {
        public int Id { get; set; }
        public string? StudentName { get; set; }
        public string? PhoneNo { get; set; }
        public int RollNo { get; set; }
        public SemesterDtoRead? Semester { get; set; }
    }
}
