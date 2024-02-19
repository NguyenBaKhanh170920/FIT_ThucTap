using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EFCore_Exa2.Applications.Entities
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        [DefaultValue(0)]
        public int Gender { get; set; }
        [Required]
        [DefaultValue("true")]
        public bool Status { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public Student(int id, string name, DateTime birthday, int gender, bool status)
        {
            Id = id;
            Name = name;
            Birthday = birthday;
            Gender = gender;
            Status = status;
        }
        public Student()
        {
            Marks = new HashSet<Mark>();
        }
    }
}
