using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Data
{
    public class DataContextFactory
    {
        private readonly DbContextOptions _options;

        public DataContext Create()
        {
            return new DataContext();
        }
    }
}
