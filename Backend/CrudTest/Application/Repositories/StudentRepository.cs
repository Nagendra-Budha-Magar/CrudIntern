using CrudTest.Data;
using CrudTest.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CrudTest.Application.Repositories
{
    public class StudentRepository : IStudentrepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Student> InsertStudent(Student entity)
        {
            _context.Students.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Student?> FindStudentById(int Id)
        {
            return await _context.Students.FindAsync(Id);
        }

        public async Task<Student?> GetStudent(int Id)
        {
            return await _context.Students
                .Include(s => s.Semester)
                .FirstOrDefaultAsync(s => s.Id == Id);
        }

        public async Task UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
