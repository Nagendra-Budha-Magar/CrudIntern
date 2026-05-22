using CrudTest.Application.Repositories;
using CrudTest.Domain.Dtos;
using CrudTest.Domain.Entity;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Diagnostics;

namespace CrudTest.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentrepository _studentrepository;

        public StudentService(IStudentrepository studentrepository)
        {
            _studentrepository = studentrepository;
        }

        public async Task<StudentDto> InsertStudent(StudentDto dto)
        {
            var student = new Student
            {
                StudentName = dto.StudentName,
                Grade = dto.Grade,
                PhoneNo = dto.PhoneNo,
                RollNo = dto.RollNo,
                SemesterId = dto.SemesterId
            };

            await _studentrepository.InsertStudent(student);

            var result = new StudentDto
            {
                StudentName = dto.StudentName,
                Grade = dto.Grade,
                PhoneNo = dto.PhoneNo,
                RollNo = dto.RollNo,
                SemesterId= dto.SemesterId
            };
            return result;
        }

        public async Task<List<StudentDtoRead>> GetAllStudents()
        {
            return await _studentrepository.GetAllStudents();
        }

        public async Task<StudentDtoRead?> GetStudent(int Id)
        {
            var student = await _studentrepository.GetStudent(Id);
            if(student is null)
            {
                return null;
            }
            return student;
        }

        public async Task<StudentDto?> UpdateStudent(int Id, StudentDto dto)
        {
            var student = await _studentrepository.FindStudentById(Id);
            if(student is null)
            {
                return null;
            }
            student.StudentName = dto.StudentName;
            student.Grade = dto.Grade;
            student.PhoneNo = dto.PhoneNo;
            student.RollNo = dto.RollNo;
            student.SemesterId = dto.SemesterId;

            await _studentrepository.UpdateStudent(student);
            var result = new StudentDto
            {
                StudentName = student.StudentName,
                Grade = student.Grade,
                PhoneNo = student.PhoneNo,
                RollNo = student.RollNo,
                SemesterId = student.SemesterId
            };
            return result;
        }

        public async Task<bool> DeleteStudent(int Id)
        {
            var result = await _studentrepository.FindStudentById(Id);
            if(result is null)
            {
                return false;
            }
            await _studentrepository.DeleteStudent(result);
            return true;
        }

    }
}
