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
    public class AddRentalViewModel : ViewModelBase
    {
        public AddRentalViewModel(NavigationStore navigationStore)
        {
            Cancel = new NavigationCommand<HomeReadersViewModel>(navigationStore, () => new HomeReadersViewModel(navigationStore));
        }
        public ICommand Cancel { get; set; }
    }
}
