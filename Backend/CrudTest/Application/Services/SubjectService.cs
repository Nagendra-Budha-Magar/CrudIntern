using CrudTest.Application.Repositories;
using CrudTest.Domain.Dtos;
using CrudTest.Domain.Entity;

namespace CrudTest.Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectrepository;

        public SubjectService(ISubjectRepository subjectrepository)
        {
            _subjectrepository = subjectrepository;
        }

        public async Task<SubjectDto> InsertSubject(SubjectDto dto)
        {
            var subject = new Subject
            {
                SubjectName = dto.SubjectName,
                Description = dto.Description,
                SubjectCode = dto.SubjectCode,
                SemesterId = dto.SemesterId
            };
            await _subjectrepository.InsertSubject(subject);

            var result = new SubjectDto
            {
                SubjectName = subject.SubjectName,
                Description = subject.Description,
                SubjectCode = subject.SubjectCode,
                SemesterId = subject.SemesterId

            };
            return result;
        }

        public async Task<SubjectDto?> GetSubject(int Id)
        {
            var subject = await _subjectrepository.GetSubject(Id);
            if (subject is null)
                return null;
            var result = new SubjectDto
            {
                SubjectName = subject.SubjectName,
                Description = subject.Description,
                SubjectCode = subject.SubjectCode,
                SemesterId = subject.SemesterId
            };
            return result;
        }

        public async Task<SubjectDto?> UpdateSubject(int Id, SubjectDto dto)
        {
            var subject = await _subjectrepository.GetSubject(Id);
            if (subject is null)
                return null;

            subject.SubjectName = dto.SubjectName;
            subject.Description = dto.Description;
            subject.SubjectCode = dto.SubjectCode;
            subject.SemesterId = dto.SemesterId;

            await _subjectrepository.UpdateSubject(subject);

            var result = new SubjectDto
            {
                SubjectName = subject.SubjectName,
                Description = subject.Description,
                SubjectCode = subject.SubjectCode,
                SemesterId = subject.SemesterId

            };
            return result;
        }

        public async Task<bool> DeleteSubject(int Id)
        {
            var subject = await _subjectrepository.GetSubject(Id);
            if (subject is null)
                return false;

            await _subjectrepository.DeleteSubject(subject);
            return true;
        }
    }
}
