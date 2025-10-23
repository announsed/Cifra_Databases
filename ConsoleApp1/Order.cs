using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

        public Order()
        {
        }

        public Order(DateTime orderDate, string status, User user, List<Product> products)
        {
            OrderDate = orderDate;
            Status = status;
            User = user;
            Products = products;
        }
    }
}
