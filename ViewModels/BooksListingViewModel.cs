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
    public class BooksListingViewModel : ViewModelBase
    {
        
        public BooksListingViewModel()
        {
            BooksListingItemVMs = new ObservableCollection<BooksListingItemViewModel>();
            this._bookRepository = new BookRepository(new DataContextFactory());
            Initialize();
            
            
            
        }

        

        
        private readonly BookRepository _bookRepository;
        private ObservableCollection<BooksListingItemViewModel> _booksListingItemVMs;
        public ObservableCollection<BooksListingItemViewModel> BooksListingItemVMs
        {
            get { return _booksListingItemVMs;}
            set
            {
                if (BooksListingItemVMs != value)
                {
                    _booksListingItemVMs = value;
                    
                }
            }
        }
        
        public async Task Initialize()
        {
            BooksListingItemVMs.Clear();
            var Result = await _bookRepository.GetAllBooksGrouped();

            for (int i = 0; i < Result.Count; i++)
            {
                BooksListingItemVMs.Add(Result[i]);
                BooksListingItemVMs[i].DeleteCommand = new FastDeleteBookCommand(Result[i].Id, this);

            }
        }
        protected override void Dispose()
        {
            
            base.Dispose();
        }
    }
}
