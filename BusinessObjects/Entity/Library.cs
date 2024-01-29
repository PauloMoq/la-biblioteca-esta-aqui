using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Entity
{
    public class Library : IEntity
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Adress { get; set; }

    }
}