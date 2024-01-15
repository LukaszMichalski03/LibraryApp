using LibraryApp.Commands;
using LibraryApp.Data;
using LibraryApp.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.ViewModels
{
    public class ReadersListingViewModel : ViewModelBase
    {
        public ReadersListingViewModel()
        {
            BooksListingItemVMs = new ObservableCollection<BooksListingItemViewModel>();
            this._bookRepository = new BookRepository(new DataContextFactory());
            Initialize();
        }




        private readonly BookRepository _bookRepository;
        private ObservableCollection<BooksListingItemViewModel> _booksListingItemVMs;
        public ObservableCollection<BooksListingItemViewModel> BooksListingItemVMs
        {
            get { return _booksListingItemVMs; }
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
            
        }
        protected override void Dispose()
        {

            base.Dispose();
        }
    }
}
