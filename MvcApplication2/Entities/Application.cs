using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Entities
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