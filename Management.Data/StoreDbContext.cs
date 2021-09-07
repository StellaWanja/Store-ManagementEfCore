using System;
using Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Data
{
    public class StoreDbContext : DbContext
    {
        //DBContext - communicate with DB
        //create tables using models - create 3 tables
        public DbSet<User> Users {get; set;}
        public DbSet<Store> Stores {get; set;}
        public DbSet<Product> Products {get; set;}

        //configuring method - is a protected method
        //create connection string
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer
                (@"Data Source= .; Initial Catalog= StoreManagement; Integrated Security=True");
        }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //est primary key
            builder.Entity<Store>()
                .HasKey(Store => Store.Id);
            //set relationship - one - many(store - products)
            builder.Entity<Store>()
                .HasMany(store => store.Products)
                .WithOne(Product => Product.Store)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(product => product.StoreId)
                .IsRequired();

        }
    }
}