using CrudTest.Application.Services;
using CrudTest.Domain.Dtos;
using CrudTest.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertStudent(StudentDto dto)
        {
            var student = await _studentService.InsertStudent(dto);
            return Ok(student);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudents();

            if (!students.Any())
                return NotFound("No students found.");

            return Ok(students);
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<IActionResult> GetStudentById(int Id)
        {
            var student = await _studentService.GetStudent(Id);
            if (student is null)
                return NotFound();
            return Ok(student);
        }

        [HttpPut]
        [Route("{Id:int}")]
        public async Task<IActionResult> UpdateStudent(int Id, StudentDto dto)
        {
            var result = await _studentService.UpdateStudent(Id, dto);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> DeleteStudent(int Id)
        {
            var result = await _studentService.DeleteStudent(Id);
            if (result is false)
                return NotFound();
            return Ok(result);
        }
    }
}
