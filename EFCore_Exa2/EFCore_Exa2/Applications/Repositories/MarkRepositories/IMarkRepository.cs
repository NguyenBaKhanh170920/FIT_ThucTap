using EFCore_Exa2.Applications.Entities;
using EFCore_Exa2.DTOs;

namespace EFCore_Exa2.Applications.Repositories.MarkRepositories
{
    public interface IMarkRepository
    {
        Task<List<MarkDisplayAllDTO>> GetAllMark();
        Task<Mark> AddMark(Mark mark);
        Task<Mark> DeleteMark(int id);
        Task<Mark> UpdateMark(Mark mark);
    }
}
