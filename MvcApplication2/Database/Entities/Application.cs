using System.Collections.Generic;

namespace MvcApplication2.Database.Entities
{
    public class Application : BaseEntity 
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public virtual ICollection<Link> Links { get; set; }
    }
}