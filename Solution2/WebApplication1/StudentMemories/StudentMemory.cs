using WebApplication1.Applications.Entities;
namespace WebApplication1.StudentMemories
{
    public class StudentMemory
    {
        public Dictionary<int, Student> Students { get; set; } = new Dictionary<int, Student>();
        public StudentMemory()
        {

        }
    }
}
