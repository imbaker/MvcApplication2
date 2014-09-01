using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Helpers;
    using System.Web.Mvc;

    using Newtonsoft.Json;

    public class Application
    {
        [HiddenInput(DisplayValue=false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public string Manufacturer { get; set; }
        public virtual ICollection<Link> Links { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Modified { get; set; }
        public string User { get; set; }
    }

    public enum CategoryEnum
    {
        WindowsApplication,
        BrowserApplication,
        WindowsService,
        DevelopmentLibrary
    }
}