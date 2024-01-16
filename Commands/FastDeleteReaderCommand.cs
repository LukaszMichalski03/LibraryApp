using LibraryApp.Data;
using LibraryApp.Repositories;
using LibraryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryApp.Commands
{
    public class FastDeleteReaderCommand : CommandBase
    {
        private readonly int _id;
        private readonly ReadersListingViewModel _readersListingView;
        ReaderRepository _readerRepository;

        public FastDeleteReaderCommand(int id, ReadersListingViewModel readersListingView)
        {
            this._id = id;
            this._readersListingView = readersListingView;
            _readerRepository = new ReaderRepository(new DataContextFactory());
        }
        public async override void Execute(object? parameter)
        {
            var result = await _readerRepository.DeleteReader(_id);
            if (result)
            {
                _readersListingView.Initialize();
                //_readersListingView.SelectedReaderListingItemViewModel = null;
            };


        }
    }
}
