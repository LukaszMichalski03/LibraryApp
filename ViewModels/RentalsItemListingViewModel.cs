using LibraryApp.Commands;
using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryApp.ViewModels
{
    public class RentalsItemListingViewModel : ViewModelBase
    {
        public RentalsItemListingViewModel() 
        {
            
        }
        private Rental _rental;
        public Rental Rental
        {
            get { return _rental; }
            set
            {
                _rental = value;

            }
        }
        public ReturnRentalCommand ReturnRentalCommand { get; set; }
    }
}
