using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Catalog;
using BusinessObjects.Entity;

namespace Services.Services
{
    public class CatalogService
    {
        public void ShowCatalog()
        {
            CatalogManager.DisplayCatalog();
        }
        public void ShowCatalog(Type type)
        {
            CatalogManager.DisplayCatalog(type);
        }
        public Book FindBook(int id)
        {
            Book livre = CatalogManager.FindBook(id);
            return livre;
        }
    }
}
