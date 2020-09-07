﻿using LibraryManangementCore.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManangementCore.Data.Interface
{
    public interface IAuthorRepository : IRepository<Author>
    {
        IEnumerable<Author> GetAllwithBooks();
        Author GetWithBooks(int id);
    }
}
