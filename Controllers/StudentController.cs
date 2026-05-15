using CrudTest.Application.Services;
using CrudTest.Domain.Dtos;
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
        [Route("{Id:int}")]
        public async Task<ActionResult> GetStudentById(int Id)
        {
            var student = await _studentService.GetStudent(Id);
            return Ok(student);
        }

        [HttpPut]
        [Route("{Id:int}")]
        public async Task<IActionResult> UpdateStudent(int Id, StudentDto dto)
        {
            return Ok(await _studentService.UpdateStudent(Id, dto));
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> DeleteStudent(int Id)
        {
            await _studentService.DeleteStudent(Id);
            return Ok("Student Deleted Successfully");
        }
    }
}
