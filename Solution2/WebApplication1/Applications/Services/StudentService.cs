using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Repositories;
using WebApplication1.DTOs;
using WebApplication1.StudentMemories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApplication1.Applications.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly StudentMemory _memories;

        public StudentService(IStudentRepository studentRepository, StudentMemory memories)
        {
            _studentRepository = studentRepository;
            _memories = memories;
        }
        public async Task<Student> Add(Student student)
        {
            try
            {
                _memories.Students.Add(student.Id, student);
                //_memories.Students.Remove(student.Id);
                var result = await _studentRepository.Add(student);
                if (result == null)
                {
                    _memories.Students.Remove(student.Id);
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Student> Delete(int id)
        {
            try
            {
                var old = _memories.Students.FirstOrDefault(x => x.Key == id).Value;
                _memories.Students.Remove(id);
                var rs = await _studentRepository.Delete(id);
                if (rs == null)
                {
                    _memories.Students.Add(id, old);
                }
                return rs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<StudentDTOs>> GetAllStudent()
        {
            return await _studentRepository.GetAllStudent();
        }

        public async Task<Student> GetStudentById(int id)
        {
            var rs = _memories.Students.FirstOrDefault(x => x.Key == id).Value;
            return rs;
        }

        public async Task<List<Student>> GetStudentsByName(string name)
        {
            var rs = _memories.Students.Values.Where(x => x.Name == name).ToList();
            //List<Student> cs = new List<Student>();
            //foreach (var stu in rs)
            //{
            //    cs.Add(stu.Value);
            //}
            return rs;
        }

        public async Task<Student> Update(Student student)
        {

            try
            {
                var old = _memories.Students.FirstOrDefault(x => x.Key == student.Id).Value;
                var update = _memories.Students.FirstOrDefault(x => x.Key == student.Id).Value;
                update.Id = student.Id;
                update.Name = student.Name;
                update.Age = student.Age;
                var rs = await _studentRepository.Update(student);
                if (rs == null)
                {
                    _memories.Students.Remove(student.Id);
                    _memories.Students.Add(old.Id, old);
                }
                return rs;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<Student> UpdateName(int id, string name)
        {
            try
            {
                var update = _memories.Students.FirstOrDefault(x => x.Key == id).Value;
                var old = _memories.Students.FirstOrDefault(x => x.Key == id).Value;
                update.Name = Name;
                var rs = await _studentRepository.Update(update);
                if (rs == null)
                {
                    _memories.Students.Remove(id);
                    _memories.Students.Add(old.Id, old);
                }

                return rs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
