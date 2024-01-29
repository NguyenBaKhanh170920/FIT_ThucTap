using EFCore_Exa2.Applications.Database;
using EFCore_Exa2.Applications.Entities;
using EFCore_Exa2.DTOs;

namespace EFCore_Exa2.Applications.Repositories.SubjectRepositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly StudentDbContext _studentDbContext;
        private readonly ILogger<SubjectRepository> _logger;
        public SubjectRepository(StudentDbContext studentDbContext, ILogger<SubjectRepository> logger)
        {
            _studentDbContext = studentDbContext;
            _logger = logger;
        }
        public async Task<Subject> AddSubject(Subject subject)
        {
            try
            {
                Subject sub2 = new Subject
                {
                    Name = subject.Name,
                    Status = subject.Status,
                };
                var rs = await _studentDbContext.AddAsync(sub2);
                if (rs != null)
                {
                    _studentDbContext.SaveChangesAsync();
                    return subject;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Subject> DeleteSubject(int id)
        {
            try
            {
                Subject sub = _studentDbContext.tbl_subject.FirstOrDefault(x => x.Id == id);
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

        public async Task<List<Subject>> GetAllSubject()
        {
            try
            {
                var rs = _studentDbContext.tbl_subject.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<SubjectDTO> GetSubjectById(int id)
        {
            try
            {
                Subject sub = _studentDbContext.tbl_subject.FirstOrDefault(x => x.Id == id);
                List<string> li2 = new List<string>();
                var li1 = (from a in _studentDbContext.tbl_student
                           join b in _studentDbContext.tbl_mark on a.Id equals b.StudentId
                           join c in _studentDbContext.tbl_subject on b.SubjectId equals c.Id
                           where c.Id == id
                           select new
                           {
                               name = a.Name + ": " + b.Scores,
                           }).ToList();
                for (int i = 0; i < li1.Count; i++)
                {
                    li2.Add(li1[i].name);
                }
                var rs = new SubjectDTO
                {
                    Id = sub.Id,
                    Name = sub.Name,
                    Status = sub.Status,
                    StudentAndMark = li2
                };
                return rs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Subject> UpdateSubject(Subject subject)
        {
            try
            {
                Subject sub = _studentDbContext.tbl_subject.FirstOrDefault(x => x.Id == subject.Id);
                if (sub != null)
                {
                    {
                        sub.Name = subject.Name;
                        sub.Status = subject.Status;
                    };
                    var rs = _studentDbContext.Update(sub);
                    if (rs != null)
                    {
                        await _studentDbContext.SaveChangesAsync();
                        return subject;
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
