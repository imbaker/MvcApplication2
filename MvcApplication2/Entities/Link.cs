using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Entities
{
    public class Link : BaseEntity
    {
        public int Id { get; set; }
        public Application ToApplication { get; set; }
        public string LinkType { get; set; }
    }
}