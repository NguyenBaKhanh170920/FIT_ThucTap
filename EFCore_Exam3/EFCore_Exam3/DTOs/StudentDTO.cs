using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EFCore_Exa2.DTOs
{
    public class StudentDTO
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
        public List<string> Score { get; set; }
    }
}
