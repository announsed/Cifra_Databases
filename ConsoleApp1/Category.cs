using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();

        public Category() { }

        public Category(string name, string description, List<Product> products)
        {
            Name = name;
            Description = description;
            Products = products;
        }
    }
}
