using LibraryApp.Commands;
using LibraryApp.Helpers;
using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryApp.ViewModels
{
    public class BooksListingItemViewModel : ViewModelBase
    {
       
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public CategoryEnum Category { get; set; }
        public int Quantity{ get; set; }
        public int Available{ get; set; }
        public FastDeleteBookCommand? DeleteCommand { get; set; }
        public AddBookToStoreCommand? AddToStoreCommand { get; set; }

    }
}
