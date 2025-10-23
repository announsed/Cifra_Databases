using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();

        public User() { }

        public User(string userName, string email, string password, List<Order> orders)
        {
            UserName = userName;
            Email = email;
            Password = password;
            Orders = orders;
        }
    }
}
