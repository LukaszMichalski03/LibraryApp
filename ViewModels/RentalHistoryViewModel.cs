using LibraryApp.Commands;
using LibraryApp.Data;
using LibraryApp.Interfaces;
using LibraryApp.Models;
using LibraryApp.Repositories;
using LibraryApp.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Resources.Extensions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryApp.ViewModels
{
    public class RentalHistoryViewModel : ViewModelBase
    {
        private ReadersListingItemViewModel _readersListingItemViewModel;
        private readonly RentalRepository _rentalRepository;
        

        public RentalHistoryViewModel(ReadersListingItemViewModel readersListingItemViewModel)
        {
            _rentalRepository = new RentalRepository(new DataContextFactory());
            _readersListingItemViewModel = readersListingItemViewModel;
            RentalsListingViewModel = new RentalsListingViewModel(new Reader() 
            {
                Id = _readersListingItemViewModel.Id,
                Name = _readersListingItemViewModel.Name,
                LastName = _readersListingItemViewModel.LastName,
                TelNumber = _readersListingItemViewModel.TelNumber,
            });            
        }
        
        public string User
        {
            get
            {
                return _readersListingItemViewModel.Name + " " + _readersListingItemViewModel.LastName;
            }
        }
        public RentalsListingViewModel RentalsListingViewModel { get; set; }
    }
}
