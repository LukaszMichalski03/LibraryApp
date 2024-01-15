using LibraryApp.Commands;
using LibraryApp.Data;
using LibraryApp.Interfaces;
using LibraryApp.Models;
using LibraryApp.Repositories;
using LibraryApp.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryApp.ViewModels
{
    public class HomeBooksViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        public HomeBooksViewModel(NavigationStore navigationStore)
        {
            
            this._navigationStore = navigationStore;
            NavigateToAddBook = new NavigationCommand<AddBookViewModel>(navigationStore, () => new AddBookViewModel(navigationStore));
            BooksListingViewModel = new BooksListingViewModel();
        }
        
        public BooksListingViewModel BooksListingViewModel { get; set; }

        public ICommand NavigateToAddBook { get; set; }
        
    }
}
