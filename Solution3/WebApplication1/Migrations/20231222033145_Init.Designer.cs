﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using WebApplication1.Applications.Database;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(Bai1DbContext))]
    [Migration("20231222033145_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication1.Applications.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("CategoryId");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("CategoryName");

                    b.HasKey("CategoryId")
                        .HasName("PK_CategoryId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Applications.Entities.Order", b =>
                {
                    b.Property<int>("OrderCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("OrderCode");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderCode"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Address");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DeliveryDate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Email");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("OrderDate");

                    b.Property<int>("Paid")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("Paid");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Phone");

                    b.Property<int>("Sale")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("Sale");

                    b.Property<int>("Status")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("Status");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("TotalPrice");

                    b.Property<string>("seller")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("seller");

                    b.HasKey("OrderCode")
                        .HasName("PK_OrderCode");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Applications.Entities.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("OrderDetailId");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailId"), 1L, 1);

                    b.Property<int>("NumberProduct")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("NumberProduct");

                    b.Property<int>("OrderCode")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("OrderCode");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("OrderDate");

                    b.Property<int>("ProductCode")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("ProductCode");

                    b.Property<int>("Sale")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("Sale");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("TotalPrice");

                    b.HasKey("OrderDetailId")
                        .HasName("PK_OrderDetailId");

                    b.ToTable("OrderDetail", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Applications.Entities.Product", b =>
                {
                    b.Property<string>("ProductCode")
                        .HasColumnType("NVARCHAR2(450)")
                        .HasColumnName("ProductCode");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("CategoryId");

                    b.Property<string>("Cost")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Cost");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Image");

                    b.Property<string>("Inventory")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Inventory");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("ProductName");

                    b.Property<string>("RentailPrice")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("RentailPrice");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Status");

                    b.Property<string>("TradekMarkId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("TradekMarkId");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Unit");

                    b.HasKey("ProductCode")
                        .HasName("PK_ProductCode");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Applications.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("Id");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Deposit")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Deposit");

                    b.Property<string>("Paid")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Paid");

                    b.Property<string>("Unpaid")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Unpaid");

                    b.HasKey("Id")
                        .HasName("PK_Id");

                    b.ToTable("Status", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Applications.Entities.Supplier", b =>
                {
                    b.Property<int>("SupplierCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("SupplierCode");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierCode"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Address");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Email");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Phone");

                    b.HasKey("SupplierCode")
                        .HasName("PK_SupplierCode");

                    b.ToTable("Supplier", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Applications.Entities.TradeMark", b =>
                {
                    b.Property<int>("TradeMarkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("TradeMarkId");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TradeMarkId"), 1L, 1);

                    b.Property<string>("TradeMarkName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("TradeMarkName");

                    b.HasKey("TradeMarkId")
                        .HasName("PK_TradeMarkId");

                    b.ToTable("TradeMark", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}