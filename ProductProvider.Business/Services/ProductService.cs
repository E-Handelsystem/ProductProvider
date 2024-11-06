using ProductProvider.Business.Models;

namespace ProductProvider.Business.Services;

public class ProductService
{
    private readonly IProductRepository productRepository;

    public ProductService(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }   

    public IEnumerable<Product> GetAllProducts()
    {
        return productRepository.GetProducts();
    }
    public string GetProductStockStatus(int productId)
    {
        var product = productRepository.GetProductById(productId);

        if (product.StockLevel > 5)
            return "I lager";
        if (product.StockLevel > 0 && product.StockLevel <= 5)
            return "Begränsat antal kvar";
        return "Slut i lager";
    }
}
