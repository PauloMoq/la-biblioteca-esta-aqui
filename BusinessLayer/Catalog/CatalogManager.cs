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
        public static IEnumerable<Book> DisplayCatalog()
        {
            IEnumerable<Book> books = bookRepository.GetAll();
            return books;
        }
        public static IEnumerable<Book> DisplayCatalog(BusinessObjects.Entity.Type type) 
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
            return bookRepository.GetAll();
        }

        public static Book FindBook(int id)
        {
            Book book = bookRepository.Get(id);
            return book;
        }
    }
}
