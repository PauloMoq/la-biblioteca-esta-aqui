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
    public class CatalogManager
    {
        static BookRepository bookRepository = new BookRepository();
        public IEnumerable<Book> DisplayCatalog()
        {
            IEnumerable<Book> books = bookRepository.GetAll();
            return books;
        }
        public IEnumerable<Book> DisplayCatalog(BusinessObjects.Entity.Type type) 
        {
            /*IEnumerable<Book> books = BookRepository.GetAll();
            IEnumerable<Book> res = new List<Book>();
            foreach (Book book in books)
            {
                if (book.type == type)
                {
                    res.Append(book);
                }
            }
            return res;*/
            IEnumerable<Book> allBooks = bookRepository.GetAll();
            IEnumerable<Book> res = from books
                                    in allBooks
                                    where allBooks.GetType().Equals(type)
                                    select books;
            return res;
        }

        public Book FindBook(int id)
        {
            Book book = bookRepository.Get(id);
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
            IEnumerable<Book> books = bookRepository.GetAll();
            foreach (Book book in books)
            {
                if(book.rate > bestRatingEver)
                {
                    bestRatingEver = (int)book.rate;
                    bestBook4Ever = book;
                }
            }
            return bestBook4Ever;
        }
    }
}
