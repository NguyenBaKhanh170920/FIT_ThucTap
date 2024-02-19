using EFCore_Exa2.Applications.Database;
using EFCore_Exa2.Applications.Entities;
using EFCore_Exa2.DTOs;

namespace EFCore_Exa2.Applications.Repositories.StudentRepositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;
        private readonly ILogger<StudentRepository> _logger;
        public StudentRepository(StudentDbContext context, ILogger<StudentRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Student> AddStudent(Student student)
        {
            try
            {
                //var rs = await _context.AddAsync(student);
                //if (rs != null)
                //{
                //    _context.SaveChangesAsync();
                //    return student;
                //}
                //return null;
                Student stu = new Student
                {
                    Name = student.Name,
                    Birthday = student.Birthday,
                    Gender = student.Gender,
                    Status = student.Status,
                };
                _context.Add(stu);
                await _context.SaveChangesAsync();
                return stu;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Student> DeleteStudent(int id)
        {
            try
            {
                Student student = _context.tbl_student.FirstOrDefault(x => x.Id == id);
                if (student != null)
                {
                    var rs = _context.Remove(student);
                    if (rs != null)
                    {
                        await _context.SaveChangesAsync();
                        return student;
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

        public async Task<List<Student>> GetAllStudent()
        {
            try
            {
                var rs = _context.tbl_student.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<StudentDTO> GetStudentById(int id)
        {
            try
            {
                Student stu1 = _context.tbl_student.FirstOrDefault(x => x.Id == id);
                List<string> sco = _context.tbl_mark.Where(x => x.StudentId == id).Select(x => x.Scores).ToList();
                StudentDTO student = new StudentDTO
                {
                    Id = id,
                    Name = stu1.Name,
                    Birthday = stu1.Birthday,
                    Gender = stu1.Gender,
                    Status = stu1.Status,
                    Score = sco
                };
                return student;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            try
            {
                Student stu1 = _context.tbl_student.FirstOrDefault(x => x.Id == student.Id);
                if (stu1 != null)
                {
                    stu1.Name = student.Name;
                    stu1.Birthday = student.Birthday;
                    stu1.Gender = student.Gender;
                    stu1.Status = student.Status;
                    var rs = _context.Update(stu1);
                    if (rs != null)
                    {
                        await _context.SaveChangesAsync();
                        return student;
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
