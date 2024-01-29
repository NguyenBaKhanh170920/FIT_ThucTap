using System;
using System.Collections.Generic;

namespace AspNetCoreWebApp.Models
{
    public partial class TbUser
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Temppass { get; set; }
    }
}
