using LibraryApp.Commands;
using LibraryApp.Data;
using LibraryApp.Models;
using LibraryApp.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.ViewModels
{
    public class RentalsListingViewModel : ViewModelBase
    {
        private Reader _reader;

        public RentalsListingViewModel(Reader reader)
        {
            _rentalsListingItemVMs = new ObservableCollection<RentalsItemListingViewModel>();
            _rentalRepository = new RentalRepository(new DataContextFactory());
            this._reader = reader;
            Initialize();
        }
        




        private readonly RentalRepository _rentalRepository;
        private ObservableCollection<RentalsItemListingViewModel> _rentalsListingItemVMs;
        public ObservableCollection<RentalsItemListingViewModel> RentalsListingItemVMs
        {
            get { return _rentalsListingItemVMs; }
            set
            {
                if (RentalsListingItemVMs != value)
                {
                    _rentalsListingItemVMs = value;

                }
            }
        }

        public async Task Initialize()
        {
            _rentalsListingItemVMs.Clear();
            ObservableCollection<RentalsItemListingViewModel> Result = await _rentalRepository.GetRentalsByReader(_reader.Id);

            for (int i = 0; i < Result.Count; i++)
            {
                _rentalsListingItemVMs.Add(Result[i]);
                Rental rental = Result[i].Rental;
                _rentalsListingItemVMs[i].ReturnRentalCommand = new ReturnRentalCommand(this, rental.Id);
            }
        }
        protected override void Dispose()
        {

            base.Dispose();
        }
    }
}
