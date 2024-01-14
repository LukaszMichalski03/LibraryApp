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
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }       
        public DbSet<Rental> Rentals { get; set; }
        
    }
}
