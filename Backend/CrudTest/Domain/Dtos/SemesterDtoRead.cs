using CrudTest.Domain.Entity;

namespace CrudTest.Domain.Dtos
{
    public class SemesterDtoRead
    {
        public string? SemesterName { get; set; }

        public ICollection<SubjectDto> SubjectsDto { get; set; } = new List<SubjectDto>();
    }
}
