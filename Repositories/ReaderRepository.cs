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
    public class ReaderRepository : IReaderRepository
    {
        private readonly DataContextFactory _contextFactory;

        public ReaderRepository(DataContextFactory contextFactory)
        {
            this._contextFactory = contextFactory;
        }

        public async Task<bool> AddReader(Reader reader)
        {
            using (DataContext context = _contextFactory.Create())
            {
                context.Readers.Add(reader);

                int result = await context.SaveChangesAsync();
                return result > 0;
            }
        }
        public async Task<bool> DeleteReader(int id)
        {
            using (DataContext context = _contextFactory.Create())
            {
                try
                {
                    var reader = await context.Readers.FindAsync(id);

                    if (reader == null)
                    {
                        return false;
                    }

                    var userRentals = context.Rentals
                    .Where(r => r.ReaderId == reader.Id)
                    .Include(r => r.Books)         
                    .ToList();

                    foreach (var rental in userRentals)
                    {
                        foreach (var book in rental.Books)
                        {
                            book.Available = true;
                        }
                    }

                    context.Rentals.RemoveRange(userRentals);

                    context.Readers.Remove(reader);

                    int result = await context.SaveChangesAsync();

                    return result > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during user deletion: {ex.Message}");
                    return false;
                }
            }
        }

        public async Task<ObservableCollection<ReadersListingItemViewModel>> GetAllReaders()
        {
            using (DataContext context = _contextFactory.Create())
            {
                List<ReadersListingItemViewModel> readers = await context.Readers
                    .Select(reader => new ReadersListingItemViewModel
                    {
                        Id = reader.Id,
                        Name = reader.Name,
                        LastName = reader.LastName,
                        TelNumber = reader.TelNumber,
                    })
                    .ToListAsync();

                return new ObservableCollection<ReadersListingItemViewModel>(readers);
            }
        }
    }
}
