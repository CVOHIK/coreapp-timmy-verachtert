using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using webshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webshop.Data
{
    public class webshopContext :DbContext
    {
        public webshopContext( DbContextOptions<webshopContext> options) : base(options){ }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ShoppingBag> Bags { get; set; }
        public DbSet<ShoppingItem> Items { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<ShoppingBag>().ToTable("ShoppingBag");
            modelBuilder.Entity<ShoppingItem>().ToTable("ShoppingItem");
            modelBuilder.Entity<Product>().ToTable("Product");
        }
    }
}
