using System.Web.Http.Results;
using Batonezas.WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Batonezas.Tests.Status
{
    [TestClass]
    public class GetStatusTests
    {
        [TestMethod]
        public void GetStatusSuccess()
        {
            var controller = new StatusController();

            var result = controller.Get();
            var contentResult = result as OkNegotiatedContentResult<int>;

            Assert.AreEqual(1, contentResult);
        }
    }
}
