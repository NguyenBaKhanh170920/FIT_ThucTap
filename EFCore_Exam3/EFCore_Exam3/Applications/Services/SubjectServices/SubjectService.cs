using EFCore_Exa2.Applications.Entities;
using EFCore_Exa2.Applications.Repositories.SubjectRepositories;
using EFCore_Exa2.DTOs;

namespace EFCore_Exa2.Applications.Services.SubjectServices
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _repository;
        public SubjectService(ISubjectRepository repository)
        {
            _repository = repository;
        }
        public async Task<Subject> AddSubject(Subject subject)
        {
            return await _repository.AddSubject(subject);
        }

        public async Task<Subject> DeleteSubject(int id)
        {
            return await (_repository.DeleteSubject(id));
        }

        public async Task<List<Subject>> GetAllSubject()
        {
            return await _repository.GetAllSubject();
        }

        public async Task<SubjectDTO> GetSubjectById(int id)
        {
            return await _repository.GetSubjectById(id);
        }

        public async Task<Subject> UpdateSubject(Subject subject)
        {
            return await _repository.UpdateSubject(subject);
        }
    }
}
