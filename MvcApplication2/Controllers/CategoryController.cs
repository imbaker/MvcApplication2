using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    using MvcApplication2.Database.Repositories.Interfaces;
    using MvcApplication2.Models;

    public class CategoryController : Controller
    {
        private readonly IUnitOfWork UnitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        //
        // GET: /Category/

        public ActionResult Index()
        {
            return View("Index", new CategoryIndexViewModel());
        }
    }
}
