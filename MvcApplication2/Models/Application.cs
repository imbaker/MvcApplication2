using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    using System.Web.Helpers;

    using Newtonsoft.Json;

    public class Application
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public virtual ICollection<Link> Links { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public string User { get; set; }
    }
}