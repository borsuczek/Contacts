using Contacts.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Contacts.Api.Models
{
    //A class for configuring database model
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add data to the Categories table
            modelBuilder.Entity<Category>().HasData(new Category { type = "inny" }) ;
            modelBuilder.Entity<Category>().HasData ( new Category { type = "służbowy" });
            modelBuilder.Entity<Category>().HasData(new Category { type = "prywatny" });

            // Add data to the Subategories table
            modelBuilder.Entity<Subcategory>().HasData(new Subcategory { name = "brak" });
            modelBuilder.Entity<Subcategory>().HasData(new Subcategory { name = "szef" });
            modelBuilder.Entity<Subcategory>().HasData(new Subcategory { name = "pracownik" });
            modelBuilder.Entity<Subcategory>().HasData(new Subcategory { name = "klient" });

            // Add data to the Conctact table
            modelBuilder.Entity<Contact>().HasData(new Contact { Email = "basic@gmail.com", Name = "Piotr", Surname = "Nowak", Password = "Pi0trek%", Phone = "222333444", Birth_date = new DateTime(2000, 1, 1, 0, 0, 0) });
            modelBuilder.Entity<Contact>().HasData(new Contact { Email = "basic2@gmail.com", Name = "Anna", Surname = "Kowalska", Password = "Kowal123", Phone = "184726334", Birth_date = new DateTime(1980, 12, 20, 0, 0, 0) });


        }


    }
}; 