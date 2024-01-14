using LibraryApp.Commands;
using LibraryApp.Interfaces;
using LibraryApp.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;


            NavigateToBookCommand = new NavigationCommand<HomeBooksViewModel>(_navigationStore, () => new HomeBooksViewModel(navigationStore));
            NavigateToReaderCommand = new NavigationCommand<HomeReadersViewModel>(_navigationStore, () => new HomeReadersViewModel());

        }

        public ICommand NavigateToBookCommand { get; set; }
        public ICommand NavigateToReaderCommand { get; set; }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
