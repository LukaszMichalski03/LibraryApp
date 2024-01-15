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
    public class AddReaderViewModel : ViewModelBase
    {

        public AddReaderViewModel(NavigationStore navigationStore)
        {
            Cancel = new NavigationCommand<HomeBooksViewModel>(navigationStore, () => new HomeBooksViewModel(navigationStore));
            AddReaderCommand = new AddReaderCommand(this);
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        public string _telNumber;
        public string TelNumber
        {
            get { return _telNumber; }
            set
            {
                _telNumber = value;
                OnPropertyChanged(nameof(TelNumber));
            }
        }
        public ICommand Cancel { get; set; }
        public AddReaderCommand AddReaderCommand { get; set; }

    }
}
