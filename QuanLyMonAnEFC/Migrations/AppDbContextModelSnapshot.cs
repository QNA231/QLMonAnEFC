﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyMonAnEFC.Entities;

#nullable disable

namespace QuanLyMonAnEFC.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuanLyMonAnEFC.Entities.CongThuc", b =>
                {
                    b.Property<int>("CongThucId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CongThucId"));

                    b.Property<string>("DonViTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MonAnId")
                        .HasColumnType("int");

                    b.Property<int>("NguyenLieuId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("CongThucId");

                    b.HasIndex("MonAnId");

                    b.HasIndex("NguyenLieuId");

                    b.ToTable("CongThuc");
                });

            modelBuilder.Entity("QuanLyMonAnEFC.Entities.LoaiMonAn", b =>
                {
                    b.Property<int>("LoaiMonAnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoaiMonAnId"));

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("LoaiMonAnId");

                    b.ToTable("LoaiMonAn");
                });

            modelBuilder.Entity("QuanLyMonAnEFC.Entities.MonAn", b =>
                {
                    b.Property<int>("MonAnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MonAnId"));

                    b.Property<string>("CachLam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("GiaBan")
                        .HasColumnType("float");

                    b.Property<string>("GioiThieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoaiMonAnId")
                        .HasColumnType("int");

                    b.Property<string>("TenMon")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("MonAnId");

                    b.HasIndex("LoaiMonAnId");

                    b.ToTable("MonAn");
                });

            modelBuilder.Entity("QuanLyMonAnEFC.Entities.NguyenLieu", b =>
                {
                    b.Property<int>("NguyenLieuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NguyenLieuId"));

                    b.Property<string>("GhiChu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNguyenLieu")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("NguyenLieuId");

                    b.ToTable("NguyenLieu");
                });

            modelBuilder.Entity("QuanLyMonAnEFC.Entities.CongThuc", b =>
                {
                    b.HasOne("QuanLyMonAnEFC.Entities.MonAn", "MonAn")
                        .WithMany()
                        .HasForeignKey("MonAnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyMonAnEFC.Entities.NguyenLieu", "NguyenLieu")
                        .WithMany()
                        .HasForeignKey("NguyenLieuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MonAn");

                    b.Navigation("NguyenLieu");
                });

            modelBuilder.Entity("QuanLyMonAnEFC.Entities.MonAn", b =>
                {
                    b.HasOne("QuanLyMonAnEFC.Entities.LoaiMonAn", "LoaiMonAn")
                        .WithMany("MonAn")
                        .HasForeignKey("LoaiMonAnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiMonAn");
                });

            modelBuilder.Entity("QuanLyMonAnEFC.Entities.LoaiMonAn", b =>
                {
                    b.Navigation("MonAn");
                });
#pragma warning restore 612, 618
        }
    }
}
