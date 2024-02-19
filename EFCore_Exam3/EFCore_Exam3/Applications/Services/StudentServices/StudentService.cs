using EFCore_Exa2.Applications.Entities;
using EFCore_Exa2.Applications.Repositories.StudentRepositories;
using EFCore_Exa2.DTOs;

namespace EFCore_Exa2.Applications.Services.StudentServices
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<Student> AddStudent(Student student)
        {
            return await _studentRepository.AddStudent(student);
        }

        public async Task<Student> DeleteStudent(int id)
        {
            return await _studentRepository.DeleteStudent(id);
        }

        public async Task<List<Student>> GetAllStudent()
        {
            return await _studentRepository.GetAllStudent();
        }

        public async Task<StudentDTO> GetStudentById(int id)
        {
            return await _studentRepository.GetStudentById(id);
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            return await _studentRepository.UpdateStudent(student);
        }
    }
}
