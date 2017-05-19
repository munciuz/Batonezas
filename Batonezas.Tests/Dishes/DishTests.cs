using System.Collections.Generic;
using System.Web.Http.Results;
using Batonezas.DataAccess;
using Batonezas.Tests.Tags;
using Batonezas.WebApi;
using Batonezas.WebApi.BusinessRules.DishCommands;
using Batonezas.WebApi.Controllers;
using Batonezas.WebApi.Infrastructure.ObjectMappings;
using Batonezas.WebApi.Models.DishModels;
using Batonezas.WebApi.Models.TagModels;
using Batonezas.WebApi.Repositories;
using Batonezas.WebApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Batonezas.Tests.Dishes
{
    [TestClass]
    public class DishTests
    {
        private readonly DishController dishController;

        private IDishService dishService;
        bool edited = false;

        public DishTests()
        {
            AutoMapperConfiguration.Configure();
            UnityConfig.RegisterComponents();

            var mockDishRepository = new Mock<IDishRepository>();
            mockDishRepository.Setup(x => x.CreateQuery()).Returns(DishData.CreateQuery);
            mockDishRepository.Setup(x => x.Get(1)).Returns(DishData.Get);
            mockDishRepository.Setup(x => x.Update(DishData.Get())).Callback(() => edited = true);

            var mockDishTagRepository = new Mock<IDishTagRepository>();

            var mockTagRepository = new Mock<ITagRepository>();
            mockTagRepository.Setup(m => m.CreateQuery()).Returns(TagData.CreateQuery);

            var mockTagService = new Mock<ITagService>();

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(m => m.Get(1)).Returns(new User { UserName = "administrator" });

            dishService = new DishService(mockDishRepository.Object, mockDishTagRepository.Object, mockTagRepository.Object, mockTagService.Object);
            dishController = new DishController(dishService);
        }

        [TestMethod]
        public void GetAllSuccess()
        {
            var result = dishController.GetAll(new DishListFilterModel());

            var castedResult = result as OkNegotiatedContentResult<IList<DishListItemModel>>;
            var resultItems = castedResult.Content;
            Assert.AreEqual(3, resultItems.Count);
        }

        [TestMethod]
        public void GetSuccess()
        {
            var result = dishController.Get(1);

            var castedResult = result as OkNegotiatedContentResult<DishEditModel>;
            var resultItems = castedResult.Content;
            Assert.AreEqual(DishData.Get().Name, resultItems.Name);
        }

        [TestMethod]
        public void EditDishCommandSuccess()
        {
            var command = new EditDishCommand(dishService);
            command.Model = new DishEditModel { Id = 1, SelectedTags = new TagListItemModel[0]};

            command.Execute();

            Assert.IsTrue(!edited);
        }
    }
}
