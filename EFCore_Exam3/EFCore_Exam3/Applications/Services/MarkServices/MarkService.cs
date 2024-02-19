using EFCore_Exa2.Applications.Entities;
using EFCore_Exa2.Applications.Repositories.MarkRepositories;
using EFCore_Exa2.DTOs;

namespace EFCore_Exa2.Applications.Services.MarkServices
{
    public class MarkService : IMarkService
    {
        private readonly IMarkRepository _markRepository;
        public MarkService(IMarkRepository markRepository)
        {
            _markRepository = markRepository;
        }

        public async Task<Mark> AddMark(Mark mark)
        {
            return await _markRepository.AddMark(mark);
        }

        public async Task<Mark> DeleteMark(int id)
        {
            return await _markRepository.DeleteMark(id);
        }

        public async Task<List<MarkDisplayAllDTO>> GetAllMark()
        {
            return await _markRepository.GetAllMark();
        }

        public async Task<Mark> UpdateMark(Mark mark)
        {
            return await _markRepository.UpdateMark(mark);
        }
    }
}
