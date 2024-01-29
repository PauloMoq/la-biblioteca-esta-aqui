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
        public void DisplayCatalog()
        {
            IEnumerable<Book> books = BookRepository.GetAll();
            Console.WriteLine(books);
        }
        public void DisplayCatalog(BusinessObjects.Entity.Type type) 
        {
            Book book = BookRepository.Get((int)type);
            Console.WriteLine(book);
        }

        public Book FindBook(int id)
        {
            Book book = BookRepository.Get(id);
            return book;
        }
    }
}
