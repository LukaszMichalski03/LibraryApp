using LibraryApp.Data;
using LibraryApp.Repositories;
using LibraryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Commands
{
    public class FastDeleteBookCommand : CommandBase
    {
        private readonly int _id;
        private readonly BooksListingViewModel booksListingView;
        BookRepository _bookRepository;

        public FastDeleteBookCommand(int id,BooksListingViewModel booksListingView)
        {
            this._id = id;
            this.booksListingView = booksListingView;
            _bookRepository = new BookRepository(new DataContextFactory());
        }
        public async override void Execute(object? parameter)
        {
            var result = await _bookRepository.DeleteBook(_id);
            if(result) booksListingView.Initialize();


        }
    }
}
