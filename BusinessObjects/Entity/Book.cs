using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Entity
{
    public class Book
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Pages { get; set; }
        public string? Type { get; set; }
        public int? Rate { get; set; }

        public Author? Author {  get; set; }

    }

    public enum Type
    {
        Fantasy,
        Aventure,
        Enseignement,
        Histoire,
        Juridique
    }
}
