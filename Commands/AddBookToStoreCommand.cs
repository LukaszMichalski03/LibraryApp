using LibraryApp.Models;
using LibraryApp.Stores;
using LibraryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Commands
{
    public class AddBookToStoreCommand : CommandBase
    {
        private BooksListingItemViewModel _booksListingItemViewModel;
        private SelectedBooksStore _selectedBooksStore;
        private readonly Book _book;        

        public AddBookToStoreCommand(BooksListingItemViewModel booksListingItemViewModel, SelectedBooksStore selectedBooksStore)
        {
            _booksListingItemViewModel = booksListingItemViewModel;
            this._selectedBooksStore = selectedBooksStore;
            _book = new Book()
            {
                Id = _booksListingItemViewModel.Id,
                Title = _booksListingItemViewModel.Title,
                Author = _booksListingItemViewModel.Author,
                Category = _booksListingItemViewModel.Category,
            };
            _selectedBooksStore.SelectedBooksChanged += OnSelectedBooksChanged;
        }
        public override bool CanExecute(object? parameter= null)
        {
            return !_selectedBooksStore.Contains(_book);
        }
        public override void Execute(object? parameter)
        {            
            _selectedBooksStore.Add(_book);
        }
        private void OnSelectedBooksChanged()
        {
            CanExecute();
        }
    }
}
