using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using LPLProject.Controllers;
using LPLProject.Models;
using System.Web.Mvc;

namespace ControllerTest
{
    [TestFixture]
    public class ControllerTestClass
    {
        [Test]
        public void testaddproject()
        {
            var obj = new HomeController();
            var actResult = obj.Index() as ViewResult;
            Assert.That(actResult.ViewName, Is.EqualTo("Index"));
        }
        [Test]
        public void addproject()
        {
            var obj = new HomeController();
            RedirectToRouteResult result = obj.select_Role("Manager") as RedirectToRouteResult;
            Assert.That(result.RouteValues["action"], Is.EqualTo("managerLogin"));

        }
        
    }
}
