using CrudTest.Domain.Dtos;

namespace CrudTest.Application.Services
{
    public interface IStudentService
    {
        Task<StudentDto> InsertStudent(StudentDto dto);
        Task<List<StudentDtoRead>> GetAllStudents();
        Task<StudentDtoRead?> GetStudent(int Id);
        Task<StudentDto?> UpdateStudent(int Id, StudentDto dto);
        Task<bool> DeleteStudent(int Id);
    }
}
