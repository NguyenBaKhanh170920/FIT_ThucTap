using EFCore_Exa2.Applications.Entities;
using EFCore_Exa2.DTOs;

namespace EFCore_Exa2.Applications.Services.MarkServices
{
    public interface IMarkService
    {
        Task<List<MarkDisplayAllDTO>> GetAllMark();
        Task<Mark> AddMark(Mark mark);
        Task<Mark> DeleteMark(int id);
        Task<Mark> UpdateMark(Mark mark);
    }
}
