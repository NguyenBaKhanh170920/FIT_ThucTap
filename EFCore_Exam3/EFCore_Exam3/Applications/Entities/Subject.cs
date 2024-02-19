using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EFCore_Exa2.Applications.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DefaultValue("true")]
        public bool Status { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public Subject()
        {
            Marks = new HashSet<Mark>();
        }
        public Subject(int id, string name, bool status)
        {
            Id = id;
            Name = name;
            Status = status;
        }
    }
}
