using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApp.Models
{
    public partial class ChungKhoanContext : DbContext
    {
        public ChungKhoanContext()
        {
        }

        public ChungKhoanContext(DbContextOptions<ChungKhoanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbBangHienThi> TbBangHienThis { get; set; } = null!;
        public virtual DbSet<TbUser> TbUsers { get; set; } = null!;
        public virtual DbSet<ViewBangDienTu> ViewBangDienTus { get; set; } = null!;
        public virtual DbSet<ViewUser> ViewUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(ConnectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbBangHienThi>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK__tb_BangH__3214CC9F9E0F7373");

                entity.ToTable("tb_BangHienThi");

                entity.Property(e => e.Ma)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BanKl1).HasColumnName("BanKL1");

                entity.Property(e => e.BanKl2).HasColumnName("BanKL2");

                entity.Property(e => e.BanKl3).HasColumnName("BanKL3");

                entity.Property(e => e.KhopLenhKl).HasColumnName("KhopLenhKL");

                entity.Property(e => e.MuaKl1).HasColumnName("MuaKL1");

                entity.Property(e => e.MuaKl2).HasColumnName("MuaKL2");

                entity.Property(e => e.MuaKl3).HasColumnName("MuaKL3");

                entity.Property(e => e.Nnban).HasColumnName("NNBan");

                entity.Property(e => e.Nnmua).HasColumnName("NNMua");

                entity.Property(e => e.Tc).HasColumnName("TC");

                entity.Property(e => e.TongKl).HasColumnName("TongKL");
            });

            modelBuilder.Entity<TbUser>(entity =>
            {
                entity.ToTable("tb_user");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Password).HasMaxLength(30);

                entity.Property(e => e.Temppass).HasMaxLength(30);
            });

            modelBuilder.Entity<ViewBangDienTu>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewBangDienTu");

                entity.Property(e => e.Ma)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Tc).HasColumnName("TC");
            });

            modelBuilder.Entity<ViewUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewUser");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
