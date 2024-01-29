using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Catalog;
using BusinessObjects.Entity;
using DataAccessLayer.Repository;

namespace Services.Services
{
    public class CatalogService
    {
        public CatalogManager catalogManager = new CatalogManager();
        public IEnumerable<Book> ShowCatalog()
        {
            IEnumerable<Book> books = catalogManager.DisplayCatalog();
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
            IEnumerable<Book> books = catalogManager.DisplayCatalog(type);
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
            Book livre = catalogManager.FindBook(id);
            return livre;
        }

        public IEnumerable<Book> findFantasyBooksInCatalog() 
        {
            return catalogManager.findFantasyBooks();
        }

        public Book findBestBookInCatalog()
        {
            return catalogManager.findBestBook();
        }
    }
}
