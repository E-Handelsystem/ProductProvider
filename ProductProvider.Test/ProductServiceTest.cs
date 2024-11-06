using Moq;
using ProductProvider.Business.Models;
using ProductProvider.Business.Services;


public class ProductServiceTests
{
    private readonly Mock<IProductRepository> mockProductRepository;
    private readonly ProductService productService;

    public ProductServiceTests()
    {
        // Skapa en mock av IProductRepository
        mockProductRepository = new Mock<IProductRepository>();

        // Ställ in mock för att returnera en lista med produkter
        mockProductRepository.Setup(repo => repo.GetProducts()).Returns(GetSampleProducts());

        // Skapa en instans av ProductService med mocken
        productService = new ProductService(mockProductRepository.Object);
    }

    [Fact]
    public void GetAllProducts_ShouldReturnProductsWithCorrectInformation()
    {
        // Act
        var products = productService.GetAllProducts().ToList();

        // Assert
        Assert.Equal(2, products.Count); // Kontrollera att vi får rätt antal produkter

        // Kontrollera varje produkts information
        Assert.Equal("Produkt A", products[0].Name);
        Assert.Equal(100, products[0].Price);
        Assert.Equal("Kategori 1", products[0].Category);
        Assert.True(products[0].IsAvailable);

        Assert.Equal("Produkt B", products[1].Name);
        Assert.Equal(200, products[1].Price);
        Assert.Equal("Kategori 2", products[1].Category);
        Assert.False(products[1].IsAvailable);
    }

    // En hjälpmetod som returnerar en lista med exempelprodukter
    private List<Product> GetSampleProducts()
    {
        return new List<Product>
        {
            new Product { Id = 1, Name = "Produkt A", Price = 100, Category = "Kategori 1", IsAvailable = true },
            new Product { Id = 2, Name = "Produkt B", Price = 200, Category = "Kategori 2", IsAvailable = false }
        };
    }
}
