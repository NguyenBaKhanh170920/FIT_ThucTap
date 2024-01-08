using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Repositories;

namespace WebApplication1.Applications.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<Student> Add(Student student)
        {
            return await _studentRepository.Add(student);
        }

        public async Task<Student> Delete(int id)
        {
            return await _studentRepository.Delete(id);
        }

        public async Task<List<Student>> GetAllStudent()
        {
            return await _studentRepository.GetAllStudent();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _studentRepository.GetStudentById(id);
        }

        public async Task<List<Student>> GetStudentsByName(string name)
        {
            return await _studentRepository.GetStudentsByName(name);
        }

        public async Task<Student> Update(Student student)
        {
            return await _studentRepository.Update(student);
        }

        public async Task<Student> UpdateName(int id, string name)
        {
            return await _studentRepository.UpdateName(id, name);
        }
    }
}
