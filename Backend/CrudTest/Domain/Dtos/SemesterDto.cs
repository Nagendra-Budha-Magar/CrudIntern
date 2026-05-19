using CrudTest.Domain.Entity;

namespace CrudTest.Domain.Dtos
{
    public class SemesterDto
    {
        public string? SemesterName { get; set; }

        public List<Subject>? Subjects { get; set; }
    }
}
