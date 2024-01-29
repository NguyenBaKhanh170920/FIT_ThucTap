using EFCore_Exa2.Applications.Database;
using EFCore_Exa2.Applications.Entities;
using EFCore_Exa2.DTOs;

namespace EFCore_Exa2.Applications.Repositories.MarkRepositories
{
    public class MarkRepository : IMarkRepository
    {
        private readonly StudentDbContext _studentDbContext;
        private readonly ILogger<MarkRepository> _logger;
        public MarkRepository(StudentDbContext studentDbContext, ILogger<MarkRepository> logger)
        {
            _studentDbContext = studentDbContext;
            _logger = logger;
        }
        public async Task<Mark> AddMark(Mark mark)
        {
            try
            {
                var rk = new Mark
                {
                    Id = mark.Id,
                    StudentId = mark.StudentId,
                    Scores = mark.Scores,
                    SubjectId = mark.SubjectId,
                    CreateDate = mark.CreateDate,
                };
                var rs = await _studentDbContext.AddAsync(rk);
                if (rs != null)
                {
                    await _studentDbContext.SaveChangesAsync();
                    return rk;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Mark> DeleteMark(int id)
        {
            try
            {
                Mark sub = _studentDbContext.tbl_mark.FirstOrDefault(x => x.Id == id);
                if (sub != null)
                {
                    var rs = _studentDbContext.Remove(sub);
                    if (rs != null)
                    {
                        await _studentDbContext.SaveChangesAsync();
                        return sub;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<List<MarkDisplayAllDTO>> GetAllMark()
        {
            var rs = (from a in _studentDbContext.tbl_mark
                      select new MarkDisplayAllDTO
                      {
                          Id = a.Id,
                          StudentId = a.StudentId,
                          SubjectId = a.SubjectId,
                          Scores = a.Scores
                      }
                    ).ToList();
            return rs;
        }

        public async Task<Mark> UpdateMark(Mark mark)
        {
            try
            {
                Mark sub = _studentDbContext.tbl_mark.FirstOrDefault(x => x.Id == mark.Id);
                if (sub != null)
                {
                    {
                        sub.StudentId = mark.StudentId;
                        sub.SubjectId = mark.SubjectId;
                        sub.Scores = mark.Scores;
                        sub.CreateDate = mark.CreateDate;
                    };
                    var rs = _studentDbContext.Update(sub);
                    if (rs != null)
                    {
                        await _studentDbContext.SaveChangesAsync();
                        return mark;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }
    }
}
