﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoeStore.Data;

#nullable disable

namespace ShoeStore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ShoeStore.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("ShoeStore.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasWarranty")
                        .HasColumnType("bit");

                    b.Property<string>("ImageFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kind")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<bool>("Washable")
                        .HasColumnType("bit");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = "20",
                            Color = "قهوه ای",
                            CompanyName = "شرکت کیف سازی",
                            HasWarranty = false,
                            ImageFileName = "1.jpg",
                            Kind = "چرمی",
                            Name = "کیف چرمی",
                            Price = 250000,
                            Washable = true,
                            Weight = "900 گرم"
                        },
                        new
                        {
                            Id = 2,
                            Amount = "20",
                            Color = "سفید",
                            CompanyName = "شرکت کیف سازی",
                            HasWarranty = false,
                            ImageFileName = "2.jpg",
                            Kind = "پارچه",
                            Name = "کیف معمولی",
                            Price = 500000,
                            Washable = true,
                            Weight = "500 گرم"
                        },
                        new
                        {
                            Id = 3,
                            Amount = "3",
                            Color = "سفید",
                            CompanyName = "نایک",
                            HasWarranty = true,
                            ImageFileName = "3.jpg",
                            Kind = "کتان",
                            Name = "کفش اسپورت",
                            Price = 23000,
                            Washable = false,
                            Weight = "600 گرم"
                        },
                        new
                        {
                            Id = 4,
                            Amount = "15",
                            Color = "سیاه",
                            CompanyName = "کفش ملی",
                            HasWarranty = false,
                            ImageFileName = "4.jpg",
                            Kind = "چرم",
                            Name = "کفش مجلسی",
                            Price = 299000,
                            Washable = true,
                            Weight = "800 گرم"
                        },
                        new
                        {
                            Id = 5,
                            Amount = "2",
                            Color = "آبی",
                            CompanyName = "کفش ملی",
                            HasWarranty = false,
                            ImageFileName = "5.jpg",
                            Kind = "چرم",
                            Name = "کفش زنانه مجلسی",
                            Price = 259000,
                            Washable = false,
                            Weight = "500 گرم"
                        },
                        new
                        {
                            Id = 6,
                            Amount = "17",
                            Color = "قهوه ای",
                            CompanyName = "شرکت چرم سازی",
                            HasWarranty = false,
                            ImageFileName = "6.jpg",
                            Kind = "چرمی",
                            Name = "کیف جیبی مردانه",
                            Price = 21000,
                            Washable = true,
                            Weight = "300 گرم"
                        },
                        new
                        {
                            Id = 7,
                            Amount = "3",
                            Color = "آبی",
                            CompanyName = "کاترپیلار",
                            HasWarranty = true,
                            ImageFileName = "7.jpg",
                            Kind = "پارچه",
                            Name = "کوله پشتی",
                            Price = 25500,
                            Washable = true,
                            Weight = "300 گرم"
                        });
                });

            modelBuilder.Entity("ShoeStore.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "1234",
                            Role = "Admin",
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Password = "1234",
                            Role = "User",
                            Username = "user"
                        });
                });

            modelBuilder.Entity("ShoeStore.Models.Cart", b =>
                {
                    b.HasOne("ShoeStore.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoeStore.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
