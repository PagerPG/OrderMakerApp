namespace OrderMakerApp.Domain
{
    public class Order
    {
        public Order(int clientId)
        {
            OrderNumber = GenerateOrderName();
            ClientId = clientId == 0 ? throw new Exception("Not valid ClientId.") : clientId;
            OrderLines = new List<OrderLine>();
        }

        public int OrderId { get; set; }

        public string OrderNumber { get; set; }
        public int ClientId { get; set; }
        public List<OrderLine> OrderLines { get; set; }

        private string GenerateOrderName() => $"Order-{DateTime.Now.ToShortDateString()}"; //OrderName = Order-19.12.2022
    }

    public class OrderLine
    {
        public OrderLine(int productId, int quantity)
        {
            ProductId = productId == 0 ? throw new Exception("Not valid ProductId.") : productId;
            Quantity = quantity <= 0 ? throw new Exception("Not valid Quantity.") : quantity;
        }

        public int OrderLineId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class Product
    {
        public Product(string productName)
        {
            ProductName = ValidateName(productName);
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }

        private static string ValidateName(string productName)
        {
            if (string.IsNullOrEmpty(productName))
                throw new Exception("Not valid ProductName.");

            if (productName.Length > 100)
                throw new Exception("Too long ProductName. Shoud has less that 100 chars.");

            return productName;
        }
    }

    public class Client
    {
        public Client(string clientName, string email)
        {
            ClientName = ValidateName(clientName);
            Email = ValidateEmail(email);
        }

        public int ClientId { get; set; }
        public string ClientName { get; set; }   
        public string Email { get; set; }

        private static string ValidateName(string clientName)
        {
            if (string.IsNullOrEmpty(clientName))
                throw new Exception("Not valid Client name.");

            if (clientName.Length > 100)
                throw new Exception("Too long Client Name. Shoud has less that 100 chars.");

            return clientName;
        }

        private static string ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new Exception("Not valid email.");

            if (!email.Contains('@'))
                throw new Exception("Invalid email");

            return email;
        }
    }
}
