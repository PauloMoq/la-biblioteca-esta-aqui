using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CatalogService
    {
        public void ShowCatalog()
        {
            DisplayCatalog();
        }
        public void ShowCatalog(Type type)
        {
            DisplayCatalog(type);
        }
        public Book FindBook(int id)
        {
            Book livre = FindBook(id);
            return livre;
        }
    }
}
