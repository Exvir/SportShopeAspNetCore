using Xunit;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using SportsStore.Controllers;
using SportsStore.Models;

namespace Tests
{
    public class ProductControllerTests
    {
        // [Fact]
        // public void Can_Paginate()
        // {
        //     var testData = new List<Product>
        //     {
        //         new Product {ProductID = 1, Name = "P1"},
        //         new Product {ProductID = 2, Name = "P2"},
        //     }.AsQueryable();
        //     var mockSet = new Mock<DbSet<Product>>();
        //     mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(testData.Provider);
        //     mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(testData.Expression);
        //     mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(testData.ElementType);
        //     mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());
        //     
        //     Mock<ApplicationDbContext> mock = new Mock<ApplicationDbContext>();
        //     mock.Setup(m => m.Set<Product>()).Returns(mockSet.Object);
        //     ProductController controller = new ProductController(mock.Object);
        //     controller.PageSize = 3;
        //
        //     // Действие
        //     var result = controller.List(2).ViewData.Model as IEnumerable<Product>;
        //
        //     Product[] prodArray = result.ToArray();
        //     Assert.True(prodArray.Length == 2);
        //     Assert.Equal("P1", prodArray[0].Name);
        //     Assert.Equal("P2", prodArray[1].Name);
        // }
    }
}