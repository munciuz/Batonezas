using Batonezas.WebApi.Models.TagModels;
using Batonezas.WebApi.Repositories;
using Batonezas.WebApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Batonezas.Tests.Tags
{
    [TestClass]
    public class TagTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mockTagRepository = new Mock<ITagRepository>();
            var mockTagService = new Mock<ITagService>(mockTagRepository);


            //mockTagService.Setup(m => m.GetList(new TagListFilterModel())).Returns(ColorData.GetAll());
            //mockColorRespository.Setup(m => m.Get(2)).Returns(ColorData.Get(2));

            //colorController = new ColorController(new ColorService(mockColorRespository.Object));
        }
    }
}
