using Microsoft.AspNetCore.Mvc;
using Moq;
using RRBL;
using RRModels;
using RRWebUI.Controllers;
using RRWebUI.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RRTests
{
    public class RestaurantControllerTest
    {
        [Fact]
        public void RestaurantControllerIndexShouldReturnList()
        {
            //Arrange
            var mockBL = new Mock<IRestaurantBL>();
            mockBL.Setup(x => x.GetAllRestaurants()).Returns(
                new List<Restaurant>()
                {
                    new Restaurant("Whataburger", "Dallas", "Texas"),
                    new Restaurant("In n Out", "Hayward", "California")
                }
                );
            var controller = new RestaurantController(mockBL.Object);
            //Act
            var result = controller.Index();
            //Assert
            //Check that we're getting a view as a result
            var viewResult = Assert.IsType<ViewResult>(result);
            //Check that the model of the viewResult is a list of restaurant VMs
            var model = Assert.IsAssignableFrom<IEnumerable<RestaurantVM>>(viewResult.ViewData.Model);
            //Check that we're getting the same amount of restaurants that we're returning
            Assert.Equal(2, model.Count());
        }
    }
}