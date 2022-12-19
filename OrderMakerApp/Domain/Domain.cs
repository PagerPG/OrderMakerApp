namespace OrderMakerApp.Domain
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public string OrderNumber { get; set; }
        public Guid ClientId { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }

    public class OrderLine
    {
        public Guid OrderLineId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }

    public class Client
    {
        public Guid ClientId { get; set; }
        public string ClientName { get; set; }   
        public string Email { get; set; }
    }
}
