using LibraryApp.Data;
using LibraryApp.Interfaces;
using LibraryApp.Models;
using LibraryApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
                    Book book = new Book()
                    {
                        Title = addBookVM.Title,
                        Author = addBookVM.Author,
                        Available = true
                    };
                    context.Books.Add(book);
                }
                int changes = await context.SaveChangesAsync();
                return changes > 0;
            }
        }

        public async Task<List<BooksListingItemViewModel>> GetAllBooksGrouped()
        {
            using (DataContext context = _contextFactory.Create())
            {
                var books = await context.Books
                    .GroupBy(b => new { b.Title, b.Author })
                    .Select(group => new
                    {
                        Book = group.First(),
                        Quantity = group.Count(),
                        QAvailable = group.Count(b => b.Available)
                    })
                    .ToListAsync();

                return books.Select(item => new BooksListingItemViewModel
                {
                    Id = item.Book.Id,
                    Title = item.Book.Title,
                    Author = item.Book.Author,
                    
                    Quantity = item.Quantity,
                    Available = item.QAvailable,
                    Category = item.Book.Category
                }).ToList();
            }
        }
    }
}
