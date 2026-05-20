using CrudTest.Domain.Dtos;

namespace CrudTest.Application.Services
{
    public interface ISubjectService
    {
        Task<SubjectDto> InsertSubject(SubjectDto dto);
        Task<SubjectDto?> GetSubject(int Id);
        Task<SubjectDto?> UpdateSubject(int Id, SubjectDto dto);
        Task<bool> DeleteSubject(int Id);
    }
}
