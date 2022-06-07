using Microsoft.EntityFrameworkCore;
using VirtualStore.Infra.Customer.Mappings;

namespace VirtualStore.Infra.Customer.Contexts;

public class MyContext : DbContext
    {
        public DbSet<VirtualStore.Domain.Customer.Entities.Customer> Customers { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VirtualStore.Domain.Customer.Entities.Customer>(new CustomerMap().Configure);
            
        }

    }