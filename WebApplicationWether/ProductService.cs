using Microsoft.EntityFrameworkCore;

namespace WebApplicationWether
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
        public Product GetProductById(int id)
        {
            return _context.Products.Find(id);
        }
        public void AddProduct(Product product, out string? status)
        {
            if (!String.IsNullOrWhiteSpace(product.Name) && product.Price > 0)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }
            else 
            {
                status = "делаешь что-то не то";
            }
            status = null;
        }
        public void UpdateProduct(Product product, out string? status)
        {
            if (_context.Entry(product) != null)
            {
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                status = "делаешь что-то не то";
            }
            status = null;
        }
        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Product> Filtracia(string name, decimal minPrice, decimal maxPrice)
        {
            var productsByName = _context.Products.Where(p => p.Name == name && p.Price >= minPrice && p.Price <= maxPrice).ToArray();

            return productsByName;
        }

    }
}
