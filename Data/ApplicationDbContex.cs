using _0306241284_NguyenKhanhHuy.Models;
using Microsoft.EntityFrameworkCore;

namespace _0306241284_NguyenKhanhHuy.Data
{
    public class ApplicationDbContex: DbContext
    {
        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options) : base(options) 
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
                entity.Property(c => c.Description)
                .HasMaxLength(150);
                entity.HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired();
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
                entity.HasMany(o => o.OrderDetail)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.OrderId);
            });
        }


    }
}
