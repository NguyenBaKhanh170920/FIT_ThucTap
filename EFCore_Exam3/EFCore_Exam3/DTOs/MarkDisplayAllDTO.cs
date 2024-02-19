using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Exa2.DTOs
{
    public class MarkDisplayAllDTO
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("tbl_student")]
        public int StudentId { get; set; }
        [Required]
        [ForeignKey("tbl_subject")]
        public int SubjectId { get; set; }
        [Required]
        [DefaultValue(0)]
        public string Scores { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
    }
}
