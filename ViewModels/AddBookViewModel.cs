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
    public class AddBookViewModel : ViewModelBase
    {
        private readonly NavigationStore navigationStore;

        public AddBookViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
            Cancel = new NavigationCommand<HomeBooksViewModel>(navigationStore, () => new HomeBooksViewModel(navigationStore));
            AddBookCommand = new AddBookCommand( this);
        }

        private string _title { get; set; }
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        private string _author { get; set; }
        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                OnPropertyChanged(nameof(Author));
            }
        }
        private string _category { get; set; }
        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }
        private int _quantity { get; set; }
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
        public AddBookCommand AddBookCommand { get; set; }
        public ICommand Cancel { get; set; }
    }
}
