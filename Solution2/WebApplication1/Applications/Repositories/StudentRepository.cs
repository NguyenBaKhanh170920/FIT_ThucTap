using WebApplication1.Applications.Database;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentRepository(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        public async Task<Student> Add(Student student)
        {
            var result = _studentDbContext.Add(student);
            if (result != null)
            {
                _studentDbContext.SaveChangesAsync();
                return student;
            }
            return null;
        }

        public async Task<Student> Delete(int id)
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

        public async Task<List<Student>> GetAllStudent()
        {
            var student = _studentDbContext.Students.ToList();
            return student;
            //throw new NotImplementedException();
        }

        public async Task<Student> GetStudentById(int id)
        {
            Student st = _studentDbContext.Students.FirstOrDefault(x => x.Id == id);
            return st;
        }

        public async Task<List<Student>> GetStudentsByName(string name)
        {
            var student = _studentDbContext.Students.Where(x => x.Name.Contains(name)).ToList();
            return student;
        }

        public async Task<Student> Update(Student student)
        {
            var result = _studentDbContext.Update(student);
            if (result != null)
            {
                _studentDbContext.SaveChangesAsync();
                return student;
            }
            return null;
        }

        public async Task<Student> UpdateName(int id, string name)
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
    }
}
