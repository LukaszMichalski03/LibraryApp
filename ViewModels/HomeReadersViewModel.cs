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
        public HomeReadersViewModel(NavigationStore navigationStore)
        {
            NavigateToAddReader = new NavigationCommand<AddReaderViewModel>(navigationStore, () => new AddReaderViewModel(navigationStore));
        }

        public ICommand NavigateToAddReader {  get; set; }
    }
}
