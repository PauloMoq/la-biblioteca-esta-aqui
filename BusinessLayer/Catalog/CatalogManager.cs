using BusinessObjects.Entity;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace BusinessLayer.Catalog
{
    public class CatalogManager : ICatalogManager
    {
        private readonly IRepository<Book> _bookRepository;

        public CatalogManager(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> DisplayCatalog()
        {
            IEnumerable<Book> books = _bookRepository.GetAll();
            return books;
        }
        public IEnumerable<Book> DisplayCatalog(BusinessObjects.Entity.Type type) 
        {
            
            
            return FilterFantasy(type);
        }

        private IEnumerable<Book> FilterFantasy(BusinessObjects.Entity.Type type)
        {
            IEnumerable<Book> allBooks = _bookRepository.GetAll();
            return from books
                                    in allBooks
                                    where allBooks.GetType().Equals(type)
                                    select books;
        }

        public Book FindBook(int id)
        {
            Book book = _bookRepository.Get(id);
            return book;
        }

        public IEnumerable<Book> findFantasyBooks()
        {
            IEnumerable<Book> res = DisplayCatalog(BusinessObjects.Entity.Type.Fantasy);
            return res;
        }

        public Book findBestBook() 
        {
            Book bestBook4Ever = new Book();
            int bestRatingEver = 0;
            IEnumerable<Book> books = _bookRepository.GetAll();
            foreach (Book book in books)
            {
                if(book.Rate > bestRatingEver)
                {
                    bestRatingEver = (int)book.Rate;
                    bestBook4Ever = book;
                }
            }
            return bestBook4Ever;
        }
    }
}
