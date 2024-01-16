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
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.ViewModels
{
    public class ReadersListingViewModel : ViewModelBase
    {
        public ReadersListingViewModel()
        {
            ReadersListingItemsVMs = new ObservableCollection<ReadersListingItemViewModel>();
            this._readerRepository = new ReaderRepository(new DataContextFactory());
            _selectedReaderStore = new SelectedReaderStore();
            SelectedReaderListingItemViewModel = null;
            Initialize();
        }




        private readonly ReaderRepository _readerRepository;
        private readonly SelectedReaderStore _selectedReaderStore;
        private ObservableCollection<ReadersListingItemViewModel> _readersListingItemVMs;
        public ObservableCollection<ReadersListingItemViewModel> ReadersListingItemsVMs
        {
            get { return _readersListingItemVMs; }
            set
            {
                if (ReadersListingItemsVMs != value)
                {
                    _readersListingItemVMs = value;
                    

                }
            }
        }
        public ReadersListingItemViewModel? SelectedReaderListingItemViewModel
        {
            get
            {
                return _readersListingItemVMs
                    .FirstOrDefault(u => u.Id == _selectedReaderStore.SelectedReader?.Id);
            }
            set
            {
                if (value?.Id != _selectedReaderStore.SelectedReader?.Id)
                {
                    _selectedReaderStore.SelectedReader = value != null
                        ? new Reader()
                        {
                            Id = value.Id,
                            Name = value.Name,
                            LastName = value.LastName,
                            TelNumber = value.TelNumber,
                        }
                        : null;
                }

            }
        }

        public async Task Initialize()
        {
            ReadersListingItemsVMs.Clear();
            var Result = await _readerRepository.GetAllReaders();

            for (int i = 0; i < Result.Count; i++)
            {
                ReadersListingItemsVMs.Add(Result[i]);
                ReadersListingItemsVMs[i].DeleteCommand = new FastDeleteReaderCommand(Result[i].Id, this);
                SelectedReaderListingItemViewModel = null;

            }
        }
        protected override void Dispose()
        {

            base.Dispose();
        }
    }
}
