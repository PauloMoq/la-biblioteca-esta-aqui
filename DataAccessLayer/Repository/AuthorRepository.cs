using BusinessObjects.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class AuthorRepository
    {
        public static IEnumerable<Author> GetAll()
        {
            return new List<Author>();
        }

        public static Author Get(int id)
        {
            return new Author();
        }
    }
}
