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
    public interface IRentalRepository
    {
        Task<bool> Add(Reader reader, ObservableCollection<Book> books);
        Task<ObservableCollection<RentalsItemListingViewModel>> GetRentalsByReader(int readerId);
        Task<bool> ReturnRental(int rentalId);
    }
}
