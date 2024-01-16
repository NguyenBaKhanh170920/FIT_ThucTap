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
    [DbContext(typeof(Bai2DbContext))]
    [Migration("20240104033359_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication1.Applications.Entities.BasketItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("Id");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Image");

                    b.Property<int>("ProductId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("ProductId");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("ProductName");

                    b.Property<int>("Quantity")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("Quantity");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Status");

                    b.HasKey("Id")
                        .HasName("PK_BasketItemsId");

                    b.ToTable("BasketItems", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Applications.Entities.Customers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AdditionalAddress")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("AdditionalAddress");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("City");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("District");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("PhoneNumber");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Street");

                    b.HasKey("Id")
                        .HasName("PK_CustomersId");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Applications.Entities.OrderItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("Id");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProductId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("ProductId");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("ProductName");

                    b.Property<int>("Quantity")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("Quantity");

                    b.HasKey("Id")
                        .HasName("PK_Id");

                    b.ToTable("OrderItems", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Applications.Entities.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("Id");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AdditionalAddress")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("AdditionalAddress");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("City");

                    b.Property<int>("CustomerId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("District");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("OrderDate");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Street");

                    b.HasKey("Id")
                        .HasName("PK_OrderId");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Applications.Entities.Products", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("ProductId");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("AvailableQuantity");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Name");

                    b.Property<int>("Price")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("Price");

                    b.HasKey("ProductId")
                        .HasName("PK_ProductId");

                    b.ToTable("Products", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}