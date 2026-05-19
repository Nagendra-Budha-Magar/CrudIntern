using CrudTest.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CrudTest.Application.Repositories
{
    public interface IStudentrepository 
    {
        Task<Student> InsertStudent(Student entity);
        Task<Student?> FindStudentById(int Id);
        Task<Student?> GetStudent(int Id);
        Task UpdateStudent(Student student);
        Task DeleteStudent(Student student);
    }   
}
