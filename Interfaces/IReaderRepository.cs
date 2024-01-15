﻿using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Interfaces
{
    public interface IReaderRepository
    {
        Task<bool> AddReader(Reader reader);
    }
}
