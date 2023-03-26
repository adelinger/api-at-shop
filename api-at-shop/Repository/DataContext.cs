using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics.Metrics;
using System.Net.Sockets;
using api_at_shop.Model;
using api_at_shop.Repository.Entities;
using api_at_shop.Repository.Entites;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.VisualBasic.FileIO;

namespace api_at_shop.Repository
    {
    public class DataContext : DbContext
    {
        public DbSet<OrderEntity> Order { get; set; }
        public DbSet<ProductOrderEntity> Product { get; set; }
        public DbSet<ProductTranslationEntity> ProductTranslations { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>(b =>
            {
                b.HasKey(e => new { e.CurrencyID });
                b.Property(p => p.USDValue).HasPrecision(18,6);
                b.Property(p => p.EURValue).HasPrecision(18, 6);
            });

            modelBuilder.Entity<OrderEntity>(o =>
            {
                o.HasKey(e => new { e.OrderID });
                o.Property(e => e.Region).IsRequired(false);
            });
            modelBuilder.Entity<ProductOrderEntity>(o =>
            {
                o.HasKey(e => new { e.ProductOrderID });
                o.Property(e => e.Sku).IsRequired(false);
            });
            modelBuilder.Entity<ProductTranslationEntity>(p => {
                p.HasKey(product => new { product.ProductTranslationID });
                p.Property(p=>p.ProductTranslationID).ValueGeneratedOnAdd();
            }); 

        }
        public DbSet<Currency> Currencies => Set<Currency>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("ShopConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

    }

}
