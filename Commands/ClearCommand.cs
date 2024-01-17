using LibraryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Commands
{
    public class ClearCommand : CommandBase
    {
        private AddRentalViewModel _addRentalViewModel;      

        public ClearCommand(AddRentalViewModel addRentalViewModel)
        {
            this._addRentalViewModel = addRentalViewModel;
        }

        public override void Execute(object? parameter)
        {
            if(_addRentalViewModel.SelectedBooks != null)
            _addRentalViewModel.SelectedBooks.Clear();
        }
    }
}
