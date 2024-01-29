using BusinessObjects.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class LibraryRepository
    {
        public static IEnumerable<Library> GetAll()
        {
            return new List<Library>();
        }

        public static Library Get(int id)
        {
            return new Library();
        }
    }
}
