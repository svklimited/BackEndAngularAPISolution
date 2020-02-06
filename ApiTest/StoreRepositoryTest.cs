using System;
using System.Collections.Generic;
using Xunit;
using ApiSolution.Model;
using ApiSolution.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace ApiTest
{
    public class StoreRepositoryTest
    {
        private readonly IQueryable<Product> products;       

        public StoreRepositoryTest()
        {
            //Arange
             products = new List<Product>
                {
                    new Product()
                    {
                     ProductName = "banana",
                     Price = 0.29m,
                     ProductQty = 20,
                     StockUpdatedOn = new DateTime(2014,04,11)
                    },
                    new Product()
                    {
                     ProductName = "honeydew melon",
                     Price = 1.01m,
                     ProductQty = 3,
                     StockUpdatedOn = new DateTime(2014,04,29)
                    },
                     new Product()
                    {
                     ProductName = "watermelon",
                     Price = 1.54m,
                     ProductQty = 4,
                     StockUpdatedOn = new DateTime(2014,04,30)
                    },
                    new Product()
                    {
                     ProductName = "apple",
                     Price = 0.41m,
                     ProductQty = 241,
                     StockUpdatedOn = new DateTime(2014,03,11)
                    },
                    new Product()
                    {
                     ProductName = "pear",
                     Price = 0.64m,
                     ProductQty = 100,
                     StockUpdatedOn = new DateTime(2014,03,14)
                    },
                    new Product()
                    {
                     ProductName = "kumquat",
                     Price = 2.04m,
                     ProductQty = 1,
                     StockUpdatedOn = new DateTime(2014,07,14)
                    }

                }.AsQueryable();

           
        }

        [Fact]
        public void GetProductsAllTest ()
        {

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());
            var mockContext = new Mock<DataContext>();
            mockContext.Setup(c => c.Products).Returns(mockSet.Object);

            //Act
            var repository = new StoreRepository(mockContext.Object);
            var actual = repository.GetProducts();

            Assert.Equal(6, actual.Count());
            Assert.Equal("apple", actual.First().ProductName);
        }

        //[Fact]
        //public void GetProductsByIdTest()
        //{

        //    var mockSet = new Mock<DbSet<Product>>();
        //    mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
        //    mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
        //    mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
        //    mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

        //    var mockContext = new Mock<DataContext>();
        //    mockContext.Setup(c => c.Products).Returns(mockSet.Obje);

        //    //Act
        //    var repository = new StoreRepository(mockContext.Object);
        //    var actual = repository.GetProductById(5);


            
        //}

        //[Fact]
        //public void AddAlltheGroceryItems()
        //{
        //    // Arrange - mocking the dbSet and the dbContext           
        //    var mockSet = new Mock<DbSet<Product>>();

        //    var mockContext = new Mock<DataContext>();
        //    mockContext.Setup(m => m.Products).Returns(mockSet.Object);

        //    // Act - Add the products collections
        //    var repository = new StoreRepository(mockContext.Object);
        //    repository.AddProducts(products);

        //    // Assert            
        //    mockSet.Verify(m => m.AddRange(It.IsAny<IEnumerable<Product>>()), Times.Once);
        //    mockContext.Verify(m => m.SaveChanges(), Times.Once);
        //}
    }
}
