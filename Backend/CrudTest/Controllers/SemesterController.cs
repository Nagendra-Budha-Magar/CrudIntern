using CrudTest.Application.Services;
using CrudTest.Domain.Dtos;
using CrudTest.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        private readonly ISemesterService _semesterService;
        public SemesterController(ISemesterService semesterService)
        {
            _semesterService = semesterService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertSemester(SemesterDto dto)
        {
            var semester = await _semesterService.InsertSemester(dto);
            return Ok(semester);
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<IActionResult> GetSemester(int Id)
        {
            var semester = await _semesterService.GetSemester(Id);
            if(semester is null)
                return NotFound();
            return Ok(semester);    
        }

        [HttpPut]
        [Route("{Id:int}")]
        public async Task<IActionResult> UpdateSemester(int Id, SemesterDto dto)
        {
            var semester = await _semesterService.UpdateSemester(Id, dto);
            if (semester is null)
                return NotFound();
            return Ok(semester);
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> DeleteSemester(int Id)
        {
            var result = await _semesterService.DeleteSemester(Id);
            if (result is false)
                return NotFound();
            return Ok(result);
        }
    }
}
