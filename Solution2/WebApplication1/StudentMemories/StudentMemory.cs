using WebApplication1.Applications.Entities;

namespace WebApplication1.StudentMemories
{
    public class StudentMemory
    {
        public Dictionary<string, Student> Students { get; set; } = new Dictionary<string, Student>();
    }
}
