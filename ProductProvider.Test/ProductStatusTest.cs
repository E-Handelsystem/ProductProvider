using Moq;
using ProductProvider.Business.Models;
using ProductProvider.Business.Services;
using Xunit;

namespace ProductProvider.Test
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> mockProductRepository;
        private readonly ProductService productService;

        public ProductServiceTests()
        {
            // Skapa en mock av IProductRepository
            mockProductRepository = new Mock<IProductRepository>();

            // Skapa en instans av ProductService med mocken
            productService = new ProductService(mockProductRepository.Object);
        }

        [Fact]
        public void GetProductStockStatus_ShouldReturn_InStock_WhenStockLevelIsAboveFive()
        {
            // Arrange
            var productId = 1;
            var product = new Product { Id = productId, Name = "Produkt A", StockLevel = 10 };
            mockProductRepository.Setup(repo => repo.GetProductById(productId)).Returns(product);

            // Act
            var status = productService.GetProductStockStatus(productId);

            // Assert
            Assert.Equal("I lager", status);
        }

        [Fact]
        public void GetProductStockStatus_ShouldReturn_LimitedStock_WhenStockLevelIsBetweenOneAndFive()
        {
            // Arrange
            var productId = 2;
            var product = new Product { Id = productId, Name = "Produkt B", StockLevel = 3 };
            mockProductRepository.Setup(repo => repo.GetProductById(productId)).Returns(product);

            // Act
            var status = productService.GetProductStockStatus(productId);

            // Assert
            Assert.Equal("Begränsat antal kvar", status);
        }

        [Fact]
        public void GetProductStockStatus_ShouldReturn_OutOfStock_WhenStockLevelIsZero()
        {
            // Arrange
            var productId = 3;
            var product = new Product { Id = productId, Name = "Produkt C", StockLevel = 0 };
            mockProductRepository.Setup(repo => repo.GetProductById(productId)).Returns(product);

            // Act
            var status = productService.GetProductStockStatus(productId);

            // Assert
            Assert.Equal("Slut i lager", status);
        }
    }
}