namespace WebApplicationWether
{
    public interface IProductService
    {
        public IEnumerable<Product> GetAllProducts();
        public Product GetProductById(int id);
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(int id);
    }
}
