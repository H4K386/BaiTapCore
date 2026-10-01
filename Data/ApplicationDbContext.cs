using System.Reflection.PortableExecutable;
using _0306241284_NguyenKhanhHuy.Models;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace _0306241284_NguyenKhanhHuy.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Category> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
                entity.HasIndex(c=>c.Name).IsUnique();
                entity.Property(c => c.Description)
                .HasMaxLength(150);
            });
            modelBuilder.Entity<Order>(entity => {
                entity.ToTable("Orders");
                entity.HasKey(o => o.Id);
                entity.Property(o => o.CustomerName)
                .HasMaxLength(100)
                .IsRequired();
                entity.Property(o => o.PhoneNumber)
                .HasMaxLength(20)
                .IsRequired();
                entity.Property(o => o.Address)
                .HasMaxLength(30)
                .IsRequired();
                entity.Property(o => o.Note)
                .HasMaxLength(30);
                entity.Property(o => o.TotalAmount)
                .HasPrecision(18, 2);
                entity.Property(o => o.Status)
                .HasConversion<string>()
                .HasMaxLength(20)
                .HasDefaultValue(OrderStatus.Pending);
                entity.Property(o => o.OrderDate)
                .HasDefaultValueSql("GetDate()");
            });
            modelBuilder.Entity<Product>(entity => {
                entity.ToTable("Products");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name)
                .HasMaxLength(250)
                .IsRequired();
                entity.HasIndex(p => p.Name).HasDatabaseName("IX_Product_Name");
                entity.Property(p => p.Price)
                .HasPrecision(18,2)
                .IsRequired();
                entity.Property(p => p.Image).HasMaxLength(250);
                entity.Property(p => p.CreateAt)
                .HasDefaultValueSql("GetDate()");
                entity.Property(p => p.Status)
                .HasDefaultValue(true);
                entity.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<OrderDetail>(entity =>
            {
               entity.ToTable("OrderDetails");
               entity.HasKey(od => od.Id);
               entity.Property(od => od.Quantity).IsRequired();
               entity.Property(od => od.Price).HasPrecision(18,2);

               entity.HasOne(od => od.Order)
               .WithMany(o => o.OrderDetail)
               .HasForeignKey(od => od.OrderId)
               .OnDelete(DeleteBehavior.Cascade);

               entity.HasOne(od => od.Product)
               .WithMany(p =>p.OrderDetail)
               .HasForeignKey(od => od.ProductId)
               .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<User>(entity =>
            {
               entity.ToTable("Users");
               entity.HasKey(u => u.Id);
               entity.Property(u => u.UserName)
               .HasMaxLength(50)
               .IsRequired();
               entity.Property(u => u.Password)
               .HasMaxLength(150)
               .IsRequired();
               entity.Property(u=>u.FullName).HasMaxLength(100);
                entity.Property(u => u.isAdmin)
                .HasDefaultValue(true);

            });
        }


    }
}
