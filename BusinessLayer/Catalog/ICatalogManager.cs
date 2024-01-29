using BusinessObjects.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Catalog
{
    public interface ICatalogManager
    {
        public IEnumerable<Book> DisplayCatalog();
        public IEnumerable<Book> DisplayCatalog(BusinessObjects.Entity.Type type);
        public Book FindBook(int id);
        public IEnumerable<Book> findFantasyBooks();
        public Book findBestBook();

    }
}
