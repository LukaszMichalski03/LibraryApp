using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Stores
{
    public class SelectedBooksStore
    {
        public SelectedBooksStore()
        {
            _selectedBooks = new ObservableCollection<Book>();
        }
        private ObservableCollection<Book> _selectedBooks;
        public ObservableCollection<Book>? SelectedBooks
        {
            get
            {
                return _selectedBooks;
            }
            set
            {
                _selectedBooks = value;
                OnSelectedBooksChanged();
            }
        }
        public bool Contains(Book book)
        {
            foreach(var item in _selectedBooks) 
            {
                if(item.Id == book.Id) return true;
            }
            return false;
        }
        public void Add(Book book)
        {
            if (!Contains(book))
            {
                _selectedBooks.Add(book);
                OnSelectedBooksChanged();
            }

        }

        public event Action SelectedBooksChanged;
        private void OnSelectedBooksChanged()
        {
            SelectedBooksChanged?.Invoke();
        }
    }
}
