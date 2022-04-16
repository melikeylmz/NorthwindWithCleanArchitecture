using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext:DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(b =>
            {
                b.ToTable("Orders").HasKey(k => k.OrderId);
                b.Property(p => p.OrderId).HasColumnName("OrderId");
                b.Property(p => p.EmplooyeeId).HasColumnName("EmployeeID");
                b.Property(p => p.CustomerId).HasColumnName("CustomerID");
                b.HasOne(p => p.Customer);
                b.HasOne(p => p.Employee);

            });

            modelBuilder.Entity<Customer>(b =>
            {
                b.ToTable("Customers").HasKey(k => k.CustomerId);
                b.Property(p => p.CustomerId).HasColumnName("CustomerID");
                 b.HasMany(p => p.Orders);
          

            });

            modelBuilder.Entity<Employee>(b =>
            {
                b.ToTable("Employees").HasKey(k => k.EmployeeId);
                b.Property(p => p.EmployeeId).HasColumnName("EmployeeID");
                b.Property(p => p.FirstName).HasColumnName("FirstName");
                b.Property(p => p.LastName).HasColumnName("LastName");
                b.HasMany(p => p.Orders);


            });
        }
    }
}
