namespace CrudTest.Domain.Entity
{
    public class Semester
    {
        public int Id { get; set; }
        public string? SemesterName { get; set; }

        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();

    }
}
