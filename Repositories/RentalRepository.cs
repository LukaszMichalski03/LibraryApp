using LibraryApp.Data;
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
    public class RentalRepository : IRentalRepository
    {
        private readonly DataContextFactory _dataContextFactory;

        public RentalRepository(DataContextFactory dataContextFactory)
        {
            this._dataContextFactory = dataContextFactory;
        }
        public async Task<bool> Add(Reader reader, ObservableCollection<Book> books)
        {
            using (DataContext context = _dataContextFactory.Create())
            {
                try
                {
                    Rental newRental = new Rental
                    {
                        ReaderId = reader.Id,
                        RentalDate = DateTime.Now,
                        ReturnDate = null
                    };
                    context.Readers.Attach(reader);
                    context.Rentals.Add(newRental);
                    await context.SaveChangesAsync();

                    foreach (Book book in books)
                    {
                        var existingBook = context.Books.Find(book.Id);
                        if (existingBook != null)
                        {
                            RentalItem rentalItem = new RentalItem
                            {
                                BookId = existingBook.Id,
                                RentalId = newRental.Id
                            };
                            context.RentalItems.Add(rentalItem);

                            existingBook.Available = false;
                        }
                        else
                        {
                            throw new Exception($"Book with Id {book.Id} does not exist in the database.");
                        }
                    }

                    int result = await context.SaveChangesAsync();

                    return result > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during adding rental: {ex.Message}");
                    return false;
                }
            }
        }

        public async Task<ObservableCollection<RentalsItemListingViewModel>> GetRentalsByReader(int readerId)
        {
            ObservableCollection<RentalsItemListingViewModel> rentalsViewModels = new ObservableCollection<RentalsItemListingViewModel>();
            using (DataContext context = _dataContextFactory.Create())
            {
                var rentals = await context.Rentals
                    .Include(r => r.Books)  // Ta linia Include powinna automatycznie załadować książki związane z wypożyczeniem
                    .Where(r => r.ReaderId == readerId)
                    .ToListAsync();

                foreach (var rental in rentals)
                {
                    var rentalViewModel = new RentalsItemListingViewModel
                    {
                        Rental = rental
                    };

                    rentalsViewModels.Add(rentalViewModel);
                }

                return rentalsViewModels;
            }
        }

        public async Task<bool> ReturnRental(int rentalId)
        {
            using (DataContext context = _dataContextFactory.Create())
            {
                var rental = await context.Rentals
                    .Include(r => r.Books)
                    .FirstOrDefaultAsync(r => r.Id == rentalId);

                if (rental == null)
                {
                    return false;
                }
                rental.ReturnDate = DateTime.Now;

                foreach (var book in rental.Books)
                {
                    book.Available = true;
                }

                await context.SaveChangesAsync();

                return true;


            }
        }
    }
}
