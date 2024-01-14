using LibraryApp.Models;
using LibraryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Interfaces
{
    public interface IBookRepository
    {
        Task<bool> AddBooks(AddBookViewModel addBookVM);
        Task<List<BooksListingItemViewModel>> GetAllBooksGrouped();
    }
}
