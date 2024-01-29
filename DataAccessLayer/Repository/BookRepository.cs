using BusinessObjects.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class BookRepository
    {
        public IEnumerable<Book> GetAll()
        {
            return new List<Book>();
        }

        public Book Get(int id)
        {
            return new Book();
        }
    }
}
