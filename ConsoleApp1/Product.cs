using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product() { }

        public Product(string name, string description, decimal price, Category category)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }
    }
}
