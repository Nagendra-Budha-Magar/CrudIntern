using CrudTest.Data;
using CrudTest.Domain.Entity;

namespace CrudTest.Application.Repositories
{
    public class SemesterRepository : ISemesterRepository
    {
        private readonly AppDbContext _context;
        public SemesterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Semester> InsertSemester(Semester entity)
        {
            _context.Semesters.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Semester?> GetSemester(int Id)
        {
            return await _context.Semesters.FindAsync(Id);
        }

        public async Task UpdateSemester(Semester semester)
        {
            _context.Semesters.Update(semester);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSemester(Semester semester)
        {
            _context.Semesters.Remove(semester);
            await _context.SaveChangesAsync();
        }
    }
}
