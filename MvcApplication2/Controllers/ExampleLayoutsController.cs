namespace MvcApplication2.Controllers
{
    using System.Web.Mvc;

    public class ExampleLayoutsController : Controller
    {
        public ActionResult Starter()
        {
            return this.View();
        }

        public ActionResult Marketing()
        {
            return this.View();
        }

        public ActionResult Fluid()
        {
            return this.View();
        }

        public ActionResult Narrow()
        {
            return this.View();
        }

        public ActionResult SignIn()
        {
            return this.View();
        }

        public ActionResult StickyFooter()
        {
            return this.View("TBD");
        }

        public ActionResult Carousel()
        {
            return this.View("TBD");
        }
    }
}
