using Microsoft.EntityFrameworkCore;
using WebApplication1.Applications.Database;
using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Services.LogServices;
using WebApplication1.DTOs;

namespace WebApplication1.Applications.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _studentDbContext;
        private readonly ILogger<StudentRepository> _logger;
        private readonly ILogService _logService;
        public StudentRepository(StudentDbContext studentDbContext, ILogger<StudentRepository> logger, ILogService logService)
        {
            _studentDbContext = studentDbContext;
            _logger = logger;
            _logService = logService;
        }
        //public void WriteLogError(string error)
        //{
        //    string logFolderName = "logs/";
        //    if (!Directory.Exists(logFolderName))
        //    {
        //        Directory.CreateDirectory(logFolderName);
        //    }
        //    string logFileName = "";
        //    DateTime now = DateTime.Now;
        //    logFileName = String.Format("{0}_{1}_{2}_log.txt",
        //        now.Year, now.Month, now.Day);
        //    string fullFileLog = Path.Combine(logFolderName, logFileName);
        //    using (StreamWriter sw = new StreamWriter(fullFileLog, true))
        //    {
        //        sw.WriteLine(String.Format("Loi xay ra vao luc: {0}", now));
        //        sw.WriteLine(String.Format("Loi cu the: {0}", error));
        //    }
        //}

        public async Task<Student> Add(Student student)
        {
            try
            {
                var result = await _studentDbContext.AddAsync(student);
                if (result != null)
                {
                    await _studentDbContext.SaveChangesAsync();
                    return result.Entity;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                _logService.WriteLogError(ex.Message);
                return null;
            }
        }

        public async Task<Student> Delete(int id)
        {
            try
            {
                var student = _studentDbContext.Students.FirstOrDefault(x => x.Id == id);
                var result = _studentDbContext.Remove(student);
                if (result != null)
                {
                    _studentDbContext.SaveChangesAsync();
                    return student;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                _logService.WriteLogError(ex.Message);
                return null;
            }
        }

        public async Task<List<StudentDTOs>> GetAllStudent()
        {
            try
            {
                var student = (from Student in _studentDbContext.Students
                               select new StudentDTOs()
                               {
                                   Id = Student.Id,
                                   Name = Student.Name,
                                   Date = DateTime.Now,
                               }).ToList();
                return student;
                //throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                _logService.
                return null;
            }
        }
        public async Task<List<Student>> GetStudent()
        {
            try
            {
                var student = _studentDbContext.Students.ToList();
                return student;
                //throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                _logService.WriteLogError(ex.Message);
                return null;
            }
        }

        public async Task<Student> GetStudentById(int id)
        {
            try
            {
                Student st = _studentDbContext.Students.FirstOrDefault(x => x.Id == id);
                return st;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                _logService.WriteLogError(ex.Message);
                return null;
            }
        }

        public async Task<List<Student>> GetStudentsByName(string name)
        {
            try
            {
                var student = await _studentDbContext.Students.Where(x => x.Name.Contains(name)).ToListAsync();
                return student;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                _logService.WriteLogError(ex.Message);
                return null;
            }
        }

        public async Task<Student> Update(Student student)
        {
            try
            {
                var result = _studentDbContext.Update(student);
                if (result != null)
                {
                    _studentDbContext.SaveChangesAsync();
                    return student;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                _logService.WriteLogError(ex.Message);
                return null;
            }
        }

        public async Task<Student> UpdateName(int id, string name)
        {
            try
            {
                Student st = _studentDbContext.Students.FirstOrDefault(x => x.Id == id);
                st.Name = name;
                var result = _studentDbContext.Update(st);
                if (result != null)
                {
                    _studentDbContext.SaveChangesAsync();
                    return st;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                _logService.WriteLogError(ex.Message);
                return null;
            }
        }
    }
}
