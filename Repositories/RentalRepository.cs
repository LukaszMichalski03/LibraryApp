using LibraryApp.Data;
using LibraryApp.Interfaces;
using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly DataContextFactory _dataContextFactory;

        public RentalRepository(DataContextFactory dataContextFactory)
        {
            this._dataContextFactory = dataContextFactory;
        }
        public async Task<bool> Add(Reader reader, ObservableCollection<Book> books)
        {
            using(DataContext context = _dataContextFactory.Create())
            {
                Rental rental = new Rental
                {
                    ReaderId = reader.Id,
                    RentalDate = DateTime.Now,
                    Books = books.ToList() 
                };

                context.Add(rental);

               int result = await context.SaveChangesAsync();
               return result > 0;
            }            
        }
    }
}
