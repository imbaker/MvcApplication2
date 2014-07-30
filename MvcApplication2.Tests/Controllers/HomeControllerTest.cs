using System.Web.Mvc;
using MvcApplication2.Controllers;
using MvcApplication2.Models;
using NSubstitute;
using Xunit;

namespace MvcApplication2.Tests.Controllers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Security.Principal;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Moq;

    using MvcApplication2.Entities;
    using MvcApplication2.Entities.Interfaces;

    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Xunit;

    using Xunit.Extensions;

    using Application = MvcApplication2.Models.Application;

    public class HomeControllerTest
    {
        public HomeControllerTest ()
        {
            var fixture = new Fixture().Customize(new MultipleCustomization());
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public void Application_WhenActionExecutes_ApplicationViewIsReturned()
        {
            // Arrange
            var fakeHttpContext = new Mock<HttpContextBase>();
            var principal = new GenericPrincipal(new GenericIdentity("User"), null);

            fakeHttpContext.Setup(t => t.User).Returns(principal);
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.Setup(t => t.HttpContext).Returns(fakeHttpContext.Object);

            var controller = new HomeController();
            controller.ControllerContext = controllerContext.Object;

            // Act
            var result = controller.Application() as ViewResult;

            // Assert
            Assert.Equal("Application", result.ViewName);
        }

        [Fact]
        public void About_WhenActionExecutes_AboutViewIsReturned ()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.About() as ViewResult;

            // Assert
            Assert.Equal("About", result.ViewName);
        }

        [Fact]
        public void Index_WhenActionExecutes_ReturnsList()
        {
            // Arrange
            var inMemoryItems = new Fakes.FakeDbSet<Entities.Application>
                                {
                                    new Entities.Application() { Id = 1, Name = "One" },
                                    new Entities.Application() { Id = 2, Name = "Two" },
                                    new Entities.Application() { Id = 3, Name = "Three" },
                                    new Entities.Application() { Id = 4, Name = "Four" }
                                };

            var mockData = Substitute.For<IContext>();
            mockData.Applications.Returns(inMemoryItems);

            var controller = new HomeController(mockData);

            // Act
            var viewResult = controller.Index() as ViewResult;
            var applicationsFromView = (IEnumerable<Entities.Application>)viewResult.Model;

            // Assert
            Assert.NotNull(applicationsFromView);
            Assert.Equal(4, applicationsFromView.Count());
            Assert.Equal(1,applicationsFromView.First().Id);
        }

        [Fact]
        public void Create_WhenActionExecutes_CreateViewIsReturned()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Create() as ViewResult;

            // Assert
            Assert.Equal("Create", result.ViewName);
        }

        [Fact]
        public void Create_WhenPostActionExecutesWithInvalidModel_CreateViewIsReturned()
        {
            // Arrange
            var controller = new HomeController();
            var model = new Models.Application();
            controller.ModelState.AddModelError("key", "error message");

            // Act
            var result = controller.Create(model) as ViewResult;

            // Assert
            Assert.Equal("Create", result.ViewName);
        }
    }
}
