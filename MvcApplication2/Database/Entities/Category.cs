namespace MvcApplication2.Database.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Category : BaseEntity
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}