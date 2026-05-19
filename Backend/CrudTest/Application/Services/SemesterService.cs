using CrudTest.Application.Repositories;
using CrudTest.Domain.Dtos;
using CrudTest.Domain.Entity;

namespace CrudTest.Application.Services
{
    public class SemesterService : ISemesterService
    {
        private readonly ISemesterRepository _semesterRepository;
        public SemesterService(ISemesterRepository semesterRepository)
        {
            _semesterRepository = semesterRepository;
        }

        public async Task<SemesterDto> InsertSemester(SemesterDto dto)
        {
            var semester = new Semester
            {
                SemesterName = dto.SemesterName
            };

            await _semesterRepository.InsertSemester(semester);

            var result = new SemesterDto
            {
                SemesterName = semester.SemesterName
            };
            return result;
        }

        public async Task<SemesterDto?> GetSemester(int Id)
        {
            var semester = await _semesterRepository.GetSemester(Id);
            if(semester is null)
            {
                return null;
            }

            var result = new SemesterDto
            {
                SemesterName = semester.SemesterName
            };
            return result;
        }

        public async Task<SemesterDto?> UpdateSemester(int Id, SemesterDto dto)
        {
            var semester = await _semesterRepository.GetSemester(Id);
            if(semester is null)
            {
                return null;
            }
            semester.SemesterName = dto.SemesterName;

            await _semesterRepository.UpdateSemester(semester);
            var result = new SemesterDto
            {
                SemesterName = semester.SemesterName
            };
            return result; 
        }

        public async Task<bool> DeleteSemester(int Id)
        {
            var semester = await _semesterRepository.GetSemester(Id);
            if(semester is null)
            {
                return false;
            }

            await _semesterRepository.DeleteSemester(semester);
            return true;
        }
    }
}
