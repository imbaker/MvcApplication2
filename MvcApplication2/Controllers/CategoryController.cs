using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using AttributeRouting.Web.Mvc;

    using AutoMapper;

    using MvcApplication2.App_Start;
    using MvcApplication2.Database.Repositories.Interfaces;
    using Entities = MvcApplication2.Database.Entities;
    using Models = MvcApplication2.Models;

    public class CategoryController : Controller
    {
        private readonly IUnitOfWork UnitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        //
        // GET: /Category/
        [GET("Category")]
        public ActionResult Index()
        {
            var model = new Models.CategoryIndexViewModel();
            model.Categories = Mapper.Map<List<Entities.Category>, List<Models.Category>>(UnitOfWork.CategoryRepository.GetAll().ToList());
            return View("Index", model);
        }
    }
}
