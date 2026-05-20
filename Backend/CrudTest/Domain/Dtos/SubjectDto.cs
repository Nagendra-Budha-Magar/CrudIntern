namespace CrudTest.Domain.Dtos
{
    public class SubjectDto
    {
        public string? SubjectName { get; set; }
        public string? Description { get; set; }
        public string? SubjectCode { get; set; }

        public int? SemesterId { get; set; }
    }
}
