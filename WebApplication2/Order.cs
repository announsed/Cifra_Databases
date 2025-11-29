namespace WebApplication2
{
    public class Order
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int NumberOrder { get; set; }

        public Order(int id, string status, int numberOrder)
        {
            Id = id;
            Status = status;
            NumberOrder = numberOrder;
        }
    }
}
