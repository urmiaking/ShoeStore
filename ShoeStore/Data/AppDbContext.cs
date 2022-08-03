using Microsoft.EntityFrameworkCore;
using ShoeStore.Models;

namespace ShoeStore.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<Item> Items { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Seed();
    }
}

public static class DataHelper
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>()
            .HasData(new Item
            {
                Id = 1,
                Name = "کیف چرمی",
                Amount = "20",
                Color = "قهوه ای",
                CompanyName = "شرکت کیف سازی",
                HasWarranty = false,
                Washable = true,
                Kind = "چرمی",
                Price = 250000,
                ImageFileName = "1.jpg",
                Weight = "900 گرم"
            });

        modelBuilder.Entity<Item>()
            .HasData(new Item
            {
                Id = 2,
                Name = "کیف معمولی",
                Amount = "20",
                Color = "سفید",
                CompanyName = "شرکت کیف سازی",
                HasWarranty = false,
                Washable = true,
                Kind = "پارچه",
                Price = 500000,
                ImageFileName = "2.jpg",
                Weight = "500 گرم"
            });

        modelBuilder.Entity<Item>()
            .HasData(new Item
            {
                Id = 3,
                Name = "کفش اسپورت",
                Amount = "3",
                Color = "سفید",
                CompanyName = "نایک",
                HasWarranty = true,
                Washable = false,
                Kind = "کتان",
                Price = 23000,
                ImageFileName = "3.jpg",
                Weight = "600 گرم"
            });

        modelBuilder.Entity<Item>()
            .HasData(new Item
            {
                Id = 4,
                Name = "کفش مجلسی",
                Amount = "15",
                Color = "سیاه",
                CompanyName = "کفش ملی",
                HasWarranty = false,
                Washable = true,
                Kind = "چرم",
                Price = 299000,
                ImageFileName = "4.jpg",
                Weight = "800 گرم"
            });

        modelBuilder.Entity<Item>()
            .HasData(new Item
            {
                Id = 5,
                Name = "کفش زنانه مجلسی",
                Amount = "2",
                Color = "آبی",
                CompanyName = "کفش ملی",
                HasWarranty = false,
                Washable = false,
                Kind = "چرم",
                Price = 259000,
                ImageFileName = "5.jpg",
                Weight = "500 گرم"
            });

        modelBuilder.Entity<Item>()
            .HasData(new Item
            {
                Id = 6,
                Name = "کیف جیبی مردانه",
                Amount = "17",
                Color = "قهوه ای",
                CompanyName = "شرکت چرم سازی",
                HasWarranty = false,
                Washable = true,
                Kind = "چرمی",
                Price = 21000,
                ImageFileName = "6.jpg",
                Weight = "300 گرم"
            });

        modelBuilder.Entity<Item>()
            .HasData(new Item
            {
                Id = 7,
                Name = "کوله پشتی",
                Amount = "3",
                Color = "آبی",
                CompanyName = "کاترپیلار",
                HasWarranty = true,
                Washable = true,
                Kind = "پارچه",
                Price = 25500,
                ImageFileName = "7.jpg",
                Weight = "300 گرم"
            });

        modelBuilder.Entity<User>()
            .HasData(new User
            {
                Id = 1,
                Username = "admin",
                Password = "1234"
            });
    }
}