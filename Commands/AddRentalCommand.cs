using LibraryApp.Models;
using LibraryApp.Repositories;
using LibraryApp.Stores;
using LibraryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryApp.Commands
{
    public class AddRentalCommand : CommandBase
    {
        private readonly SelectedBooksStore _selectedBooksStore;
        private readonly SelectedReaderStore _selectedReaderStore;
        private readonly NavigationStore _navigationStore;
        private readonly RentalRepository _rentalRepository;
        
        public Reader reader { get; private set; }
        public ObservableCollection<Book> books { get; private set; }

        public AddRentalCommand(SelectedBooksStore selectedBooksStore, SelectedReaderStore selectedReaderStore, NavigationStore navigationStore)
        {
           
            _rentalRepository = new RentalRepository(new Data.DataContextFactory());
            this._selectedBooksStore = selectedBooksStore;
            this._selectedReaderStore = selectedReaderStore;
            this._navigationStore = navigationStore;
            _selectedBooksStore.SelectedBooksChanged += Update;
            _selectedReaderStore.SelectedUserChanged += Update;
            Update();
        }
        private void Update()
        {
            reader = _selectedReaderStore.SelectedReader;

            books = new ObservableCollection<Book>(_selectedBooksStore.SelectedBooks);
        }
        public override bool CanExecute(object? parameter)
        {
            return _selectedReaderStore.SelectedReader != null; 
        }
        public async override void Execute(object? parameter)
        {
            if(reader != null)
            {
                var result = await _rentalRepository.Add(reader, books);
                if (result)
                {
                    _selectedBooksStore.SelectedBooks.Clear();
                    _navigationStore.CurrentViewModel = new HomeReadersViewModel(_navigationStore);
                }
            }
            

            Update();

        }
    }
}
