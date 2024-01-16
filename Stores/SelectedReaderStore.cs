using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Stores
{
    public class SelectedReaderStore
    {
        private Reader _selectedReader;
        public Reader? SelectedReader
        {
            get
            {
                return _selectedReader;
            }
            set
            {
                _selectedReader = value;
                OnSelectedUserChanged();
            }
        }

        public event Action SelectedUserChanged;
        private void OnSelectedUserChanged()
        {
            SelectedUserChanged?.Invoke();
        }
    }
}
