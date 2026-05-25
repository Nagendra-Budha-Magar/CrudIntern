using CrudTest.Data;
using CrudTest.Domain.Dtos;
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

        public async Task<List<StudentDtoRead>> GetAllStudents()
        {
            return await _context.Students
                .Select(s => new StudentDtoRead
                {
                    Id = s.Id,
                    StudentName = s.StudentName,
                    PhoneNo = s.PhoneNo,
                    RollNo = s.RollNo,
                    Semester = new SemesterDtoRead
                    {
                        SemesterName = s.Semester!.SemesterName,
                        SubjectsDto = s.Semester.Subjects
                            .Select(sub => new SubjectDto
                            {
                                SubjectName = sub.SubjectName,
                                Description = sub.Description,
                                SubjectCode = sub.SubjectCode,
                                SemesterId = sub.SemesterId
                            }).ToList()
                    }
                })
                .ToListAsync();
        }

        public async Task<Student?> FindStudentById(int Id)
        {
            return await _context.Students.FindAsync(Id);
        }

        public async Task<StudentDtoRead?> GetStudent(int Id)
        {
            return await _context.Students
                .Where(s => s.Id == Id)
                .Select(s => new StudentDtoRead
                {
                    Id = s.Id,
                    StudentName = s.StudentName,
                    PhoneNo = s.PhoneNo,
                    RollNo = s.RollNo,
                    Semester = new SemesterDtoRead
                    {
                        SemesterName = s.Semester!.SemesterName,
                        SubjectsDto = s.Semester.Subjects
                        .Select(sub => new SubjectDto
                        {
                            SubjectName = sub.SubjectName,
                            Description = sub.Description,
                            SubjectCode = sub.SubjectCode,
                            SemesterId = sub.SemesterId
                        }).ToList()
                    }
                }).FirstOrDefaultAsync();
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
