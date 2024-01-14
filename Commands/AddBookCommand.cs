using LibraryApp.Data;
using LibraryApp.Interfaces;
using LibraryApp.Repositories;
using LibraryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Commands
{
    public class AddBookCommand : CommandBase
    {
        private readonly BookRepository _bookRepository;
        private readonly AddBookViewModel _addBookVM;

        public AddBookCommand( AddBookViewModel addBookVM)
        {
            _bookRepository = new BookRepository(new DataContextFactory());
            this._addBookVM = addBookVM;
        }
        public override async void Execute(object? parameter)
        {
            var result = await _bookRepository.AddBooks(_addBookVM);
            if (result)
            {
                _addBookVM.Author = string.Empty;
                _addBookVM.Title = string.Empty;
                _addBookVM.Category = string.Empty;
                _addBookVM.Quantity = 0;
            }
        }
    }
}
