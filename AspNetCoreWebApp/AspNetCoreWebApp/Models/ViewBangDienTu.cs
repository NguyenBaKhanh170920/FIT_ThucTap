using System;
using System.Collections.Generic;

namespace AspNetCoreWebApp.Models
{
    public partial class ViewBangDienTu
    {
        public string Ma { get; set; } = null!;
        public double Tc { get; set; }
        public double Tran { get; set; }
        public double San { get; set; }
    }
}
