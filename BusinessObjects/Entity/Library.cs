using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Entity
{
    public class Library : AEntity
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Adress { get; set; }

    }
}