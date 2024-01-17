using LibraryApp.Components;
using LibraryApp.Data;
using LibraryApp.Repositories;
using LibraryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Commands
{
    public class ReturnRentalCommand : CommandBase
    {
        private readonly RentalsListingViewModel _rentalsListingVM;
        private readonly int _rentalId;
        private readonly RentalRepository _rentalRepository;

        public ReturnRentalCommand(RentalsListingViewModel rentalsListingVM, int rentalId)
        {
            _rentalRepository = new RentalRepository(new DataContextFactory());
            _rentalsListingVM = rentalsListingVM;
            this._rentalId = rentalId;
        }
        public async override void Execute(object? parameter)
        {
            var result = await _rentalRepository.ReturnRental(_rentalId);
            if (result) _rentalsListingVM.Initialize();
        }
    }
}
