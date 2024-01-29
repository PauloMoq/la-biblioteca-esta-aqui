using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Entity
{
    public class Book : IEntity
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? pages { get; set; }
        public Type type { get; set; }
        public int? rate { get; set; }

        public Author? author {  get; set; }

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
