namespace WebApplicationWether
{
    public interface IProductService
    {
        public IEnumerable<Product> GetAllProducts();
        public Product GetProductById(int id);
        public void AddProduct(Product product, out string? status);
        public void UpdateProduct(Product product, out string? status);
        public void DeleteProduct(int id);
        public IEnumerable<Product> Filtracia(string name, decimal minPrice, decimal maxPrice);
    }
}
