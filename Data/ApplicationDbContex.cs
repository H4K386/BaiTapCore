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

            });
        }

    }
}
