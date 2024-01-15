using LibraryApp.Data;
using LibraryApp.Interfaces;
using LibraryApp.Models;
using System;
using System.Collections.Generic;
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
    }
}
