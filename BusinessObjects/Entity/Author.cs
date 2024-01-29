using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Entity
{
    public class Author : IEntity
    {
        [Key]
        public int? Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
    }
}