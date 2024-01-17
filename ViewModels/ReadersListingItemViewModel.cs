using LibraryApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryApp.ViewModels
{
    public class ReadersListingItemViewModel : ViewModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string TelNumber { get; set; }
        public FastDeleteReaderCommand DeleteCommand { get; set; }
        public ICommand RentalHistoryCommand { get; set; }
    }
}
