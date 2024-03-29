﻿using System;
using System.Collections.Generic;

namespace EFCore_Exam1.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Price { get; set; }
        public int? Status { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
