using LibraryApp.Commands;
using LibraryApp.Models;
using LibraryApp.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryApp.ViewModels
{
    public class AddRentalViewModel : ViewModelBase
    {
        private readonly SelectedReaderStore _selectedReaderStore;
        private readonly SelectedBooksStore _selectedBooksStore;

        public AddRentalViewModel(NavigationStore navigationStore, SelectedReaderStore selectedReaderStore, SelectedBooksStore selectedBooksStore)
        {
            _selectedReaderStore = selectedReaderStore;
            _selectedBooksStore = selectedBooksStore;
            Cancel = new NavigationCommand<HomeReadersViewModel>(navigationStore, () => new HomeReadersViewModel(navigationStore));
            AddRental = new AddRentalCommand(_selectedBooksStore, _selectedReaderStore, navigationStore);
            BooksSearchViewModel = new BooksSearchViewModel(_selectedBooksStore);
            ClearCommand = new ClearCommand(this);


        }
        public ObservableCollection<Book>? SelectedBooks => _selectedBooksStore.SelectedBooks;
        public Reader? SelectedReader => _selectedReaderStore.SelectedReader;
        public BooksSearchViewModel BooksSearchViewModel { get; set; }
        public ICommand Cancel { get; set; }
        public AddRentalCommand AddRental { get; set; }
        public ClearCommand ClearCommand { get; set; }
    }
}
