namespace EFCore_Exa2.DTOs
{
    public class SubjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public List<string> StudentAndMark { get; set; }


    }
}
