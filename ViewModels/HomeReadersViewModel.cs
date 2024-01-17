using LibraryApp.Commands;
using LibraryApp.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryApp.ViewModels
{
    public class HomeReadersViewModel : ViewModelBase
    {
        private SelectedReaderStore _selectedReaderStore;
        private SelectedBooksStore _selectedBooksStore;
        public HomeReadersViewModel(NavigationStore navigationStore)
        {
            _selectedReaderStore = new SelectedReaderStore();
            _selectedBooksStore = new SelectedBooksStore();
            NavigateToAddReader = new NavigationCommand<AddReaderViewModel>(navigationStore, () => new AddReaderViewModel(navigationStore));
            NavigateToAddRental = new NavigationCommand<AddRentalViewModel>(navigationStore, () => new AddRentalViewModel(navigationStore, _selectedReaderStore, _selectedBooksStore));
            ReadersListingViewModel = new ReadersListingViewModel(_selectedReaderStore);
        }
        public ReadersListingViewModel ReadersListingViewModel { get; set; }
        public ICommand NavigateToAddReader {  get; set; }
        public ICommand NavigateToAddRental {  get; set; }
    }
}
