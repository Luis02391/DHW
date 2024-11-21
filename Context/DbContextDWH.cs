using DWHNorthwindOrders.Entities.DWH;
using DWHNorthwindOrders.Entities.North;
using Microsoft.EntityFrameworkCore;

namespace DWHNorthwindOrders.Context
{

    public class DbContextDwh : DbContext
    {
        public DbContextDwh(DbContextOptions<DbContextDwh> options) : base(options) { }

        
        public DbSet<DimEmployee> DimEmployees { get; set; }
        public DbSet<DimProduct> DimProducts { get; set; }
        public DbSet<DimSupplier> DimSuppliers { get; set; }
        public DbSet<DimShipper> DimShippers { get; set; }
        public DbSet<DimCategory> DimCategories { get; set; }
        public DbSet<DimCustomer> DimCustomers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DimEmployee>().ToTable("DimEmployee", "DWH");
            modelBuilder.Entity<DimProduct>().ToTable("DimProduct", "DWH");
            modelBuilder.Entity<DimSupplier>().ToTable("DimSupplier", "DWH");
            modelBuilder.Entity<DimShipper>().ToTable("DimShipper", "DWH");
            modelBuilder.Entity<DimCategory>().ToTable("DimCategory", "DWH");
            modelBuilder.Entity<DimCustomer>().ToTable("DimCustomer","DWH");
            
            modelBuilder.Entity<DimCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerID);
            });
            modelBuilder.Entity<DimProduct>(entity =>
            {
                entity.HasKey(e => e.ProductID);
            });

            modelBuilder.Entity<DimShipper>(entity =>
            {
                entity.HasKey(e => e.ShipperID);
            });
            modelBuilder.Entity<DimSupplier>(entity =>
            {
                entity.HasKey(e => e.SupplierID);
            });
            modelBuilder.Entity<DimCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryID);
            });
            modelBuilder.Entity<DimEmployee>(entity =>
            {
             
                entity.HasKey(e => e.EmployeeID);
            });

           
            modelBuilder.Entity<DimEmployee>()
                .HasOne<DimEmployee>()
                .WithMany()
                .HasForeignKey(d => d.ReportsTo)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<DimEmployee>()
                .HasOne<Shipper>()
                .WithMany()
                .HasForeignKey(e => e.ReportsTo)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    }
