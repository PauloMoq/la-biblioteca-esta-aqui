using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Entity
{
    public class Book : AEntity
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Pages { get; set; }
        public Type Type { get; set; }
        public int? Rate { get; set; }

        [ForeignKey(nameof(Author.Id))]
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
