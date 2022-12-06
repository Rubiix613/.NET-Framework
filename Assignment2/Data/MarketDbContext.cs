using System;
using System.Runtime.ConstrainedExecution;
using Assignment2.Models;
using Microsoft.EntityFrameworkCore;
namespace Assignment2.Data
{
    public class MarketDbContext : DbContext
    {
        public MarketDbContext(DbContextOptions<MarketDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Broker> Brokers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Broker>().ToTable("Broker");
            modelBuilder.Entity<Subscription>().ToTable("Subscription");
            modelBuilder.Entity<Subscription>().HasKey(c => new { c.ClientId, c.BrokerId });
        }

    }
}

