using CrudTest.Domain.Entity;

namespace CrudTest.Application.Repositories
{
    public interface ISubjectRepository
    {
        Task<Subject> InsertSubject(Subject subject);
        Task<Subject?> GetSubject(int Id);
        Task UpdateSubject(Subject subject);
        Task DeleteSubject(Subject subject);
    }
}
