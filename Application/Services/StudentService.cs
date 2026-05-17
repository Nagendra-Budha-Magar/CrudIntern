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
                RollNo = dto.RollNo
            };

            await _studentrepository.InsertStudent(student);

            var result = new StudentDto
            {
                StudentName = dto.StudentName,
                Grade = dto.Grade,
                PhoneNo = dto.PhoneNo,
                RollNo = dto.RollNo
            };
            return result;
        }

        public async Task<StudentDto?> GetStudent(int Id)
        {
            var student = await _studentrepository.GetStudent(Id);
            if(student is null)
            {
                return null;
            }

            var result = new StudentDto
            {
                StudentName = student.StudentName,
                Grade = student.Grade,
                PhoneNo = student.PhoneNo,
                RollNo = student.RollNo
            };
            return result;
        }

        public async Task<StudentDto?> UpdateStudent(int Id, StudentDto dto)
        {
            var student = await _studentrepository.GetStudent(Id);
            if(student is null)
            {
                return null;
            }
            student.StudentName = dto.StudentName;
            student.Grade = dto.Grade;
            student.PhoneNo = dto.PhoneNo;
            student.RollNo = dto.RollNo;

            await _studentrepository.UpdateStudent(student);
            var result = new StudentDto
            {
                StudentName = student.StudentName,
                Grade = student.Grade,
                PhoneNo = student.PhoneNo,
                RollNo = student.RollNo
            };
            return result;
        }

        public async Task<bool> DeleteStudent(int Id)
        {
            var result = await _studentrepository.GetStudent(Id);
            if(result is null)
            {
                return false;
            }
            await _studentrepository.DeleteStudent(result);
            return true;
        }

    }
}
