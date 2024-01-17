using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    public class Reader
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string TelNumber { get; set; }


        public List<Rental> Rentals { get; set; } = new List<Rental>();
    }
}
