﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Catalog;
using BusinessObjects.Entity;

namespace Services.Services
{
    public class CatalogService
    {
        public IEnumerable<Book> ShowCatalog()
        {
            IEnumerable<Book> books = CatalogManager.DisplayCatalog();
            #if DEBUG
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
            #endif
            return books;

        }
        public IEnumerable<Book> ShowCatalog(BusinessObjects.Entity.Type type)
        {
            IEnumerable<Book> books = CatalogManager.DisplayCatalog(type);
            #if DEBUG
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
            #endif
            return books;
        }
        public Book FindBook(int id)
        {
            Book livre = CatalogManager.FindBook(id);
            return livre;
        }
    }
}
