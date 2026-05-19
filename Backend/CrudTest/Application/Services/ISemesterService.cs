using CrudTest.Domain.Dtos;

namespace CrudTest.Application.Services
{
    public interface ISemesterService
    {
        Task<SemesterDto> InsertSemester(SemesterDto dto);
        Task<SemesterDto?> GetSemester(int Id);
        Task<SemesterDto?> UpdateSemester(int Id, SemesterDto dto);
        Task<bool> DeleteSemester(int Id);
    }
}
