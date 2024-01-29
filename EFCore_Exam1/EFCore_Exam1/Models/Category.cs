using System;
using System.Collections.Generic;

namespace EFCore_Exam1.Models
{
    public partial class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Status { get; set; }
    }
}
