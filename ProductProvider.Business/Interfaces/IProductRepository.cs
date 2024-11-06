namespace ProductProvider.Business.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);

    }
}
