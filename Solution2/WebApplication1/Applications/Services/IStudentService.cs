using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudent();
        Task<Student> GetStudentById(int id);
        Task<Student> Add(Student student);
        Task<Student> Update(Student student);
        Task<Student> Delete(int id);
        Task<List<Student>> GetStudentsByName(string name);
        Task<Student> UpdateName(int id, string name);

    }
}
