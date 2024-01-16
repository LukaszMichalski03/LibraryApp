using LibraryApp.Data;
using LibraryApp.Helpers;
using LibraryApp.Interfaces;
using LibraryApp.Models;
using LibraryApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContextFactory _contextFactory;

        public BookRepository(DataContextFactory contextFactory)
        {
            this._contextFactory = contextFactory;
        }
        public async Task<bool> AddBooks(AddBookViewModel addBookVM)
        {
            using (DataContext context = _contextFactory.Create())
            {
                for (int q = 0; q < addBookVM.Quantity; q++)
                {
                    if (Enum.TryParse(addBookVM.Category, out CategoryEnum category))
                    {
                        Book book = new Book()
                        {
                            Title = addBookVM.Title,
                            Author = addBookVM.Author,
                            Category = category,
                            Available = true
                        };
                        context.Books.Add(book);
                    }
                }
                int changes = await context.SaveChangesAsync();
                return changes > 0;
            }
        }

        public async Task<bool> DeleteBook(int id)
        {
            using (DataContext context = _contextFactory.Create())
            {
                var book = context.Books.FirstOrDefault(b  => b.Id == id);
                context.Books.Remove(book);
                int changes = await context.SaveChangesAsync();
                return changes > 0;
            }
        }

        public async Task<ObservableCollection<BooksListingItemViewModel>> GetAllBooksGrouped()
        {
            using (DataContext context = _contextFactory.Create())
            {
                var books = await context.Books
                    .GroupBy(b => new { b.Title, b.Author })
                    .Select(group => new
                    {

                        Book = group.FirstOrDefault(b => b.Available) ?? group.First(),
                        Quantity = group.Count(),
                        QAvailable = group.Count(b => b.Available)
                    })
                    .ToListAsync();

                ObservableCollection<BooksListingItemViewModel> observableCollection = new ObservableCollection<BooksListingItemViewModel>();

                foreach (var item in books)
                {
                    observableCollection.Add(new BooksListingItemViewModel
                    {
                        Id = item.Book.Id,
                        Title = item.Book.Title,
                        Author = item.Book.Author,
                        Quantity = item.Quantity,
                        Available = item.QAvailable,
                        Category = item.Book.Category
                    });
                }

                return observableCollection;
            }
        }

    }
}
