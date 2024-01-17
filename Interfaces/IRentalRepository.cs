using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Interfaces
{
    public interface IRentalRepository
    {
        Task<bool> Add(Reader reader, ObservableCollection<Book> books);
    }
}
