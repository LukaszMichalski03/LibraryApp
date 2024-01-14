using LibraryApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool Available { get; set; }
        public CategoryEnum Category { get; set; }
        public ICollection<Rental> Rentals { get; set; }
    }
}
