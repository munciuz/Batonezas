using System.Collections.Generic;
using System.Web.Http.Results;
using Batonezas.DataAccess;
using Batonezas.WebApi.BusinessRules.TagCommands;
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
    public class RoleTests
    {
        private readonly TagController tagController;

        ITagService tagService;

        public RoleTests()
        {
            AutoMapperConfiguration.Configure();

            var mockTagRepository = new Mock<ITagRepository>();
            mockTagRepository.Setup(m => m.CreateQuery()).Returns(TagData.CreateQuery);
            mockTagRepository.Setup(m => m.Get(1)).Returns(TagData.Get);
            mockTagRepository.Setup(m => m.Update(TagData.Get()));
            mockTagRepository.Setup(m => m.Insert(TagData.Get()));
            
            var mockDishTagRepository = new Mock<IDishTagRepository>();

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(m => m.Get(1)).Returns(new User {UserName = "administrator"});

            tagService = new TagService(mockTagRepository.Object, mockDishTagRepository.Object, mockUserRepository.Object);
            tagController = new TagController(tagService);
        }

        [TestMethod]
        public void GetAllSuccess()
        {
            var result = tagController.GetAll(new TagListFilterModel());

            var castedResult = result as OkNegotiatedContentResult<IList<TagListItemModel>>;
            var resultItems = castedResult.Content;
            Assert.AreEqual(4, resultItems.Count);
        }

        [TestMethod]
        public void GetSuccess()
        {
            var result = tagController.Get(1);

            var castedResult = result as OkNegotiatedContentResult<TagEditModel>;
            var resultItems = castedResult.Content;
            Assert.AreEqual(TagData.Get().Name, resultItems.Name);
        }

        [TestMethod]
        public void UpdateTagCommand()
        {
            var command = new EditTagCommand(tagService);
            command.Model = new TagEditModel() { Id = 1 };

            command.Execute();

            Assert.IsTrue(true);
        }
    }
}
