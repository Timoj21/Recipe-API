

using AutoMapper;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using RecipeAPI.Controllers;
using RecipeAPI.Interfaces;
using RecipeAPI.Models;

namespace Category.Test
{
    public class CategoryController
    {
        [Fact]
        public async void Test1()
        {
            // Arrange
            int count = 5;
            var dataStore = A.Fake<ICategoryRepository>();
            var mapper = A.Fake<IMapper>();
            var fakeCategories = A.CollectionOfDummy<CategoryItem>(count).AsEnumerable();
            var controller = new RecipeAPI.Controllers.CategoryController(dataStore, mapper);

            // Act
            var actionResult = controller.GetCategories();

            // Assert
            var result = actionResult as OkObjectResult;
            var returnCategories = result.Value as ICollection<CategoryItem>;
            Assert.Equal(count, returnCategories.Count());
        }
    }
}