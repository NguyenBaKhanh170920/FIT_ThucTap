namespace AspNetCoreWebApp.Models
{
    public partial class TbBangHienThi
    {
        public string Ma { get; set; } = null!;
        public double Tc { get; set; }
        public double Tran { get; set; }
        public double San { get; set; }
        public double? MuaG3 { get; set; }
        public int? MuaKl3 { get; set; }
        public double? MuaG2 { get; set; }
        public int? MuaKl2 { get; set; }
        public double? MuaG1 { get; set; }
        public int? MuaKl1 { get; set; }
        public double? KhopLenhGia { get; set; }
        public int? KhopLenhKl { get; set; }
        public double? TileTangGiam { get; set; }
        public double? BanG1 { get; set; }
        public int? BanKl1 { get; set; }
        public double? BanG2 { get; set; }
        public int? BanKl2 { get; set; }
        public double? BanG3 { get; set; }
        public int? BanKl3 { get; set; }
        public int? TongKl { get; set; }
        public double? MoCua { get; set; }
        public double? CaoNhat { get; set; }
        public double? ThapNhat { get; set; }
        public int? Nnmua { get; set; }
        public int? Nnban { get; set; }
        public int? Room { get; set; }
        public TbBangHienThi(string ma, double tc, double tran, double san, double? muaG3, int? muaKl3, double? muaG2, int? muaKl2, double? muaG1, int? muaKl1, double? khopLenhGia, int? khopLenhKl, double? tileTangGiam, double? banG1, int? banKl1, double? banG2, int? banKl2, double? banG3, int? banKl3, int? tongKl, double? moCua, double? caoNhat, double? thapNhat, int? nnmua, int? nnban, int? room)
        {
            Ma = ma;
            Tc = tc;
            Tran = tran;
            San = san;
            MuaG3 = muaG3;
            MuaKl3 = muaKl3;
            MuaG2 = muaG2;
            MuaKl2 = muaKl2;
            MuaG1 = muaG1;
            MuaKl1 = muaKl1;
            KhopLenhGia = khopLenhGia;
            KhopLenhKl = khopLenhKl;
            TileTangGiam = tileTangGiam;
            BanG1 = banG1;
            BanKl1 = banKl1;
            BanG2 = banG2;
            BanKl2 = banKl2;
            BanG3 = banG3;
            BanKl3 = banKl3;
            TongKl = tongKl;
            MoCua = moCua;
            CaoNhat = caoNhat;
            ThapNhat = thapNhat;
            Nnmua = nnmua;
            Nnban = nnban;
            Room = room;
        }
    }
}
