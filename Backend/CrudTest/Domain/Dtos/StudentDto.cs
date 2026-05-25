using CrudTest.Domain.Entity;

namespace CrudTest.Domain.Dtos
{
    public class StudentDto
    {
        public string? StudentName { get; set; }
        public string? PhoneNo { get; set; }
        public int RollNo { get; set; }
        public int? SemesterId { get; set; }
    }
}
