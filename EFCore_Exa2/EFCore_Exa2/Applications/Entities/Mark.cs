using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Exa2.Applications.Entities
{
    public class Mark

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
        public virtual Student? StudentNavigation { get; set; }
        public virtual Subject? SubjectNavigation { get; set; }
        public Mark(int id, int studentId, int subjectId, string scores, DateTime createDate)
        {
            Id = id;
            StudentId = studentId;
            SubjectId = subjectId;
            Scores = scores;
            CreateDate = createDate;
        }
        public Mark() { }
    }
}
