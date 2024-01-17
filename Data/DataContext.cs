using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Data
{
    public class DataContext : DbContext
    {
                
        public DataContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\Łukasz\\Desktop\\POProjektWSB\\LibraryDBTest.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(eb =>
            {
                eb.HasMany(b => b.Rentals)
                .WithMany(r => r.Books)
                .UsingEntity<RentalItem>(
                    w => w.HasOne(ri => ri.Rental)
                    .WithMany()
                    .HasForeignKey(ri => ri.RentalId),

                    w => w.HasOne(ri => ri.Book)
                    .WithMany()
                    .HasForeignKey(ri => ri.BookId),

                    ri =>
                    {
                        ri.HasKey(ri => ri.Id);
                    }
                    );
            });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }       
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<RentalItem> RentalItems { get; set; }
        
        
    }
}
