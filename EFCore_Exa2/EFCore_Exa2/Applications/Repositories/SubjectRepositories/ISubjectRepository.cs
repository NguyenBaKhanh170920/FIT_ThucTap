using EFCore_Exa2.Applications.Entities;
using EFCore_Exa2.DTOs;

namespace EFCore_Exa2.Applications.Repositories.SubjectRepositories
{
    public interface ISubjectRepository
    {
        Task<Subject> AddSubject(Subject subject);
        Task<Subject> UpdateSubject(Subject subject);
        Task<Subject> DeleteSubject(int id);
        Task<List<Subject>> GetAllSubject();
        Task<SubjectDTO> GetSubjectById(int id);
    }
}
