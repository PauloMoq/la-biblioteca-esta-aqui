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
        public static void DisplayCatalog()
        {
            IEnumerable<Book> books = BookRepository.GetAll();
            Console.WriteLine(books);
        }
        public static void DisplayCatalog(BusinessObjects.Entity.Type type) 
        {
            Book book = BookRepository.Get((int)type);
            Console.WriteLine(book);
        }

        public static Book FindBook(int id)
        {
            Book book = BookRepository.Get(id);
            return book;
        }
    }
}
