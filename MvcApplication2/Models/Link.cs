using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Link
    {
        public int Id { get; set; }

        public Application ToApplication { get; set; }

        public string Type { get; set; }
    }
}
