namespace OrderMakerApp.Domain
{
    public class Order
    {
        public Order(int clientId)
        {
            OrderNumber = GenerateOrderName();
            ClientId = clientId;
            OrderLines = new List<OrderLine>();
        }

        public int OrderId { get; set; }

        public string OrderNumber { get; set; }
        public int ClientId { get; set; }
        public List<OrderLine> OrderLines { get; set; }

        public void AddOrderLine(int quantityId, int productId)
        {
            OrderLines.Add(new OrderLine(productId, quantityId));
        }

        private string GenerateOrderName() => $"Order-{DateTime.Now.ToShortDateString()}"; //OrderName = Order-19.12.2022
    }

    public class OrderLine
    {
        public OrderLine(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public int OrderLineId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class Product
    {
        public Product(string productName)
        {
            ProductName = productName;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }

    public class Client
    {
        public Client(string clientName, string email)
        {
            ClientName = clientName;
            Email = email;
        }

        public int ClientId { get; set; }
        public string ClientName { get; set; }   
        public string Email { get; set; }

       
    }
}
