using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Catalog;

namespace Services.Services
{
    public class CatalogService
    {
        public void ShowCatalog()
        {
            Catalog.DisplayCatalog();
        }
        public void ShowCatalog(Type type)
        {
            Catalog.DisplayCatalog(type);
        }
        public Book FindBook(int id)
        {
            Book livre = Catalog.FindBook(id);
            return livre;
        }
    }
}
