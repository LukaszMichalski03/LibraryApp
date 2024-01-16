using LibraryApp.Models;
using LibraryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Interfaces
{
    public interface IReaderRepository
    {
        Task<bool> AddReader(Reader reader);
        Task<bool> DeleteReader(int id);
        Task<ObservableCollection<ReadersListingItemViewModel>>GetAllReaders();
    }
}
