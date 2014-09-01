using System.Web.Mvc;
using MvcApplication2.Controllers;
using Moq;
using NUnit.Framework;

namespace MvcApplication2.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Security.Principal;
    using System.Web;

    using FluentAssertions;

    using MvcApplication2.Database.Repositories.Interfaces;

    using MvcContrib.TestHelper;

    using Entities = MvcApplication2.Database.Entities;

    public class HomeControllerTest
    {
        [Test]
        public void Application_WhenActionExecutes_ApplicationViewIsReturned()
        {
            // Arrange
            var principal = new GenericPrincipal(new GenericIdentity("User"), null);
            var fakeHttpContext = Mock.Of<HttpContextBase>(m => m.User == principal);

            var controllerContext = Mock.Of<ControllerContext>(m => m.HttpContext == fakeHttpContext);

            var controller = new HomeController(Mock.Of<IUnitOfWork>());
            controller.ControllerContext = controllerContext;

            // Act
            var result = controller.Application() as ViewResult;

            // Assert
            result.ViewName.Should().BeEquivalentTo("Application");
        }

        [Test]
        public void About_WhenActionExecutes_AboutViewIsReturned ()
        {
            // Arrange
            var controller = new HomeController(Mock.Of<IUnitOfWork>());

            // Act
            var result = controller.About();

            // Assert
            result.AssertViewRendered().ForView("About");
        }

        [Test]
        public void Index_WhenActionExecutes_ReturnsList()
        {
            // Arrange
            var inMemoryItems = new Fakes.FakeDbSet<Entities.Application>
                                {
                                    new Entities.Application { Id = 1, Name = "One" },
                                    new Entities.Application { Id = 2, Name = "Two" },
                                    new Entities.Application { Id = 3, Name = "Three" },
                                    new Entities.Application { Id = 4, Name = "Four" }
                                };

            var mockData = Mock.Of<IUnitOfWork>(m => m.ApplicationRepository.GetAll() == inMemoryItems);

            var controller = new HomeController(mockData);

            // Act
            var viewResult = controller.Index() as ViewResult;
            var applicationsFromView = (IEnumerable<Entities.Application>)viewResult.Model;

            // Assert
            applicationsFromView.Should().HaveCount(4, "because repository contains four items");
            applicationsFromView.Should().ContainInOrder(inMemoryItems, "because item order should be unchanged");
        }

        [Test]
        public void Create_WhenActionExecutes_CreateViewIsReturned()
        {
            // Arrange
            var controller = new HomeController(Mock.Of<IUnitOfWork>());

            // Act
            var result = controller.Create();

            // Assert
            result.AssertViewRendered().ForView("Create");
        }

        [Test]
        public void Create_WhenPostActionExecutesWithInvalidModel_CreateViewIsReturned()
        {
            // Arrange
            var controller = new HomeController(Mock.Of<IUnitOfWork>());
            var model = new Models.Application();
            controller.ModelState.AddModelError("key", "error message");

            // Act
            var result = controller.Create(model) as ViewResult;

            // Assert
            result.AssertViewRendered().ForView("Create");
        }
    }
}
