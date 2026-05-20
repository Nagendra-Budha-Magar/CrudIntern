namespace CrudTest.Domain.Entity
{
    public class Subject
    {
        public int Id { get; set; }
        public string? SubjectName { get; set; }
        public string? Description { get; set; }
        public string? SubjectCode { get; set; }

        public int? SemesterId { get; set; }

    }
}
