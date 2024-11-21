using DWHNorthwindOrders.Entities.North;
using Microsoft.EntityFrameworkCore;

namespace DWHNorthwindOrders.Context
{
    public class DbContextNw : DbContext
    {
        public DbContextNw(DbContextOptions<DbContextNw> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>().ToTable("Suppliers");
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Shipper>().ToTable("Shippers");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Product>().ToTable("Products");
        }
    }
}
