using LibraryApp.Data;
using LibraryApp.Models;
using LibraryApp.Repositories;
using LibraryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Commands
{
    public class AddReaderCommand : CommandBase
    {
        private readonly AddReaderViewModel _readerVM;
        private ReaderRepository _readerRepository; 

        public AddReaderCommand(AddReaderViewModel readerVM)
        {
            this._readerVM = readerVM;
            _readerRepository = new ReaderRepository(new DataContextFactory());
        }
        public async override void Execute(object? parameter)
        {
            Reader reader = new Reader()
            {
                Name = _readerVM.Name,
                LastName = _readerVM.LastName,
                TelNumber = _readerVM.TelNumber,
            };
            var result = await _readerRepository.AddReader(reader);
            if (result)
            {
                _readerVM.Name = string.Empty;
                _readerVM.LastName = string.Empty;
                _readerVM.TelNumber = string.Empty;
            }
        }

    }
}
