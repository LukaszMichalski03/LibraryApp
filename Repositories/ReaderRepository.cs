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
                var reader = context.Readers.FirstOrDefault(b => b.Id == id);
                context.Readers.Remove(reader);
                int changes = await context.SaveChangesAsync();
                return changes > 0;
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
