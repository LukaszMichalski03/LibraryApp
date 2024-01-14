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
    public class BooksListingViewModel : ViewModelBase
    {
        public event Action BooksListChanged;
        public BooksListingViewModel(BookRepository bookRepository)
        {
            BooksListChanged += OnBooksListChanged;
            this._bookRepository = bookRepository;
        }

        

        private List<BooksListingItemViewModel> _booksListingItemVMs;
        private readonly BookRepository _bookRepository;

        public List<BooksListingItemViewModel> BooksListingItemVMs
        {
            get { return _booksListingItemVMs;}
            set
            {
                if (_booksListingItemVMs != value)
                {
                    _booksListingItemVMs = value;
                    BooksListChanged?.Invoke();
                    
                }
            }
        }
        //SelectedBooksListingItemVMs ???
        private void OnBooksListChanged()
        {
            Initialize();
        }
        private async Task Initialize()
        {
            _booksListingItemVMs.Clear();
            _booksListingItemVMs = await _bookRepository.GetAllBooksGrouped();
        }
        protected override void Dispose()
        {
            BooksListChanged -= OnBooksListChanged;
            base.Dispose();
        }
    }
}
