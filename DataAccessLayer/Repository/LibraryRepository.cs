using BusinessObjects.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class LibraryRepository : IRepository<Library>
    {

        private readonly LibraryContext _libraryContext;

        public LibraryRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public IEnumerable<Library> GetAll()
        {
            return _libraryContext.Libraries.ToArray();
        }

        public Library Get(int id)
        {
            return _libraryContext.Libraries.Single(Library => Library.Id == id);
        }
    }
}
