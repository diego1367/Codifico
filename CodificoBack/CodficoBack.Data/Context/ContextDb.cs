using CodficoBack.Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CodficoBack.Data.Context
{
    public class ContextDb : DbContext
    {
        private string _connectionString;

        public ContextDb(DbContextOptions options, string connectionString = null)
             : base(options)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!string.IsNullOrEmpty(_connectionString))
            {
                options.UseSqlServer(_connectionString);
            }
            base.OnConfiguring(options);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
                .ToTable("OrderDetails", schema: "Sales")
                .HasKey(od => new { od.OrderId, od.ProductId });
            modelBuilder.Entity<Customer>()
                .ToTable("Customers", schema: "Sales")
                .HasKey(c => c.CustId);
            modelBuilder.Entity<Shipper>()
                .ToTable("Shippers", schema: "Sales")
                .HasKey(e => e.ShipperId);
            modelBuilder.Entity<Product>()
                .ToTable("Products", schema: "Production")
                .HasKey(e => e.ProductId);
            modelBuilder.Entity<Employee>()
          .ToTable("Employees", schema: "HR")
          .HasKey(e => e.EmpId);
            modelBuilder.Entity<Employee>()
                 .HasOne(e => e.Manager)
                 .WithMany(e => e.Subordinates)
                 .HasForeignKey(e => e.ManagerId)
                 .HasConstraintName("FK_Employee_Manager");

            modelBuilder.Entity<Order>()
                .ToTable("Orders", schema: "Sales") 
                .HasKey(o => o.OrderId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Employee)
                .WithMany()
                .HasForeignKey(o => o.EmpId);
            modelBuilder.Entity<SalesPrediction>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<SalesPrediction> SalesPredictions { get; set; }



    }
}
