using LibraryApp.Commands;
using LibraryApp.Data;
using LibraryApp.Models;
using LibraryApp.Repositories;
using LibraryApp.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.ViewModels
{
    public class BooksSearchViewModel : ViewModelBase
    {
        public BooksSearchViewModel(SelectedBooksStore selectedBooksStore)
        {
            _selectedBooksStore = selectedBooksStore;
            BooksListingItemVMs = new ObservableCollection<BooksListingItemViewModel>();
            _bookRepository = new BookRepository(new DataContextFactory());
            _searchText = string.Empty;
            Initialize();
                
        }
        private string _searchText;
        private readonly BookRepository _bookRepository;
        private readonly SelectedBooksStore _selectedBooksStore;
        private ObservableCollection<BooksListingItemViewModel> _booksListingItemVMs;
        public ObservableCollection<BooksListingItemViewModel> BooksListingItemVMs
        {
            get { return _booksListingItemVMs; }
            set
            {
                if (_booksListingItemVMs != value)
                {
                    _booksListingItemVMs = value;
                }
            }
        }
        
        

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    Initialize();
                }
            }
        }

        public async Task Initialize()
        {
            BooksListingItemVMs.Clear();
            var Result = await _bookRepository.GetBooksByTitleOrAuthor(SearchText);
            
            for (int i = 0; i < Result.Count; i++)
            {
                BooksListingItemVMs.Add(Result[i]);
                BooksListingItemVMs[i].AddToStoreCommand = new AddBookToStoreCommand(BooksListingItemVMs[i], _selectedBooksStore);
            }            
        }
        

    }
}

