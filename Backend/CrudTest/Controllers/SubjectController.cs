using CrudTest.Application.Services;
using CrudTest.Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectservice;
        public SubjectController(ISubjectService subjectservice)
        {
            _subjectservice = subjectservice;
        }

        [HttpPost]
        public async Task<IActionResult> InsertSubject(SubjectDto dto)
        {
            var result = await _subjectservice.InsertSubject(dto);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<IActionResult> GetStudentById(int Id)
        {
            var result = await _subjectservice.GetSubject(Id);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut]
        [Route("{Id:int}")]
        public async Task<IActionResult> UpdateSubject(int Id, SubjectDto dto)
        {
            var result = await _subjectservice.UpdateSubject(Id, dto);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> DeleteSubject(int Id)
        {
            var result = await _subjectservice.DeleteSubject(Id);
            if (result is false)
                return NotFound();
            return Ok(result);
        }
    }
}
