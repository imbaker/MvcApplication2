using AttributeRouting.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    using System.Data.Entity;
    using System.Web.Http.ModelBinding;

    using MvcApplication2.Database.Entities.Interfaces;
    using MvcApplication2.Models;

    using Newtonsoft.Json;

    using Application = MvcApplication2.Database.Entities.Application;

    public class HomeController : Controller
    {
        private IContext Context { get; set; }

        public HomeController(IContext context = null)
        {
            Context = context;
        }


        [GET("/")]
        public ViewResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            var applications = Context.Applications.ToList();

            return View(applications);
        }

        [HttpGet]
        [GET("Application")]
        public ActionResult Application()
        {
            var application = new Models.Application() { Id = 1, Name = "Textpad", Manufacturer="Helios Software", Created = DateTime.Now };
            application.User = User.Identity.Name;
            var links = new List<Link>()
                        {
                            new Link()
                            {
                                Id = 1,
                                ToApplication = new Models.Application() { Id = 2, Name = "Application 2", Manufacturer= "Company 2" }
                            },
                            new Link()
                            {
                                Id = 2,
                                ToApplication = new Models.Application() { Id = 3, Name = "Application 3", Manufacturer = "Company 3" }
                            }
                        };
            return View("Application", application);
        }


        [GET("About")]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View("About");
        }

        
        [GET("Contact")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [GET("Create")]
        public ViewResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [POST("Create")]
        public ActionResult Create(Models.Application model)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }

            return this.HttpNotFound();
        }
    }
}
