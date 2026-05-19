using CrudTest.Domain.Entity;

namespace CrudTest.Application.Repositories
{
    public interface ISemesterRepository

    {
        Task<Semester> InsertSemester(Semester entity);
        Task<Semester?> GetSemester(int Id);
        Task UpdateSemester(Semester semester);
        Task DeleteSemester(Semester semester);
    }
}
