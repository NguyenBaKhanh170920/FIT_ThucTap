using EFCore_Exa2.Applications.Entities;
using EFCore_Exa2.DTOs;

namespace EFCore_Exa2.Applications.Repositories.StudentRepositories
{
    public interface IStudentRepository
    {
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<Student> DeleteStudent(int id);
        Task<List<Student>> GetAllStudent();
        Task<StudentDTO> GetStudentById(int id);
    }
}
