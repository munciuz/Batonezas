using System.Collections.Generic;
using System.Web.Http.Results;
using Batonezas.WebApi.Controllers;
using Batonezas.WebApi.Infrastructure.ObjectMappings;
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
        //private readonly TagController tagController;

        //public TagTests()
        //{
        //    AutoMapperConfiguration.Configure();

        //    var mockTagRepository = new Mock<ITagRepository>();
        //    mockTagRepository.Setup(m => m.CreateQuery()).Returns(TagData.CreateQuery);

        //    var mockDishTagRepository = new Mock<IDishTagRepository>();
        //    //var mockTagService = new Mock<ITagService>(mockTagRepository);

        //    //tagController = new TagController(new TagService(mockTagRepository.Object, mockDishTagRepository.Object));
        //}

        //[TestMethod]
        //public void GetAllSuccess()
        //{
        //    //var result = tagController.GetAll(new TagListFilterModel());

        //    //var castedResult = result as OkNegotiatedContentResult<IList<TagListItemModel>>;
        //    //var resultItems = castedResult.Content;
        //    //Assert.AreEqual(4, resultItems.Count);
        //}
    }
}
