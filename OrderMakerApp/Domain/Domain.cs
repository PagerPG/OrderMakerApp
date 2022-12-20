namespace OrderMakerApp.Domain
{
    public record OrderId : Id
    {
        public OrderId(int id) : base(id) { }

        public static explicit operator int(OrderId id) => id.Value;
        public static explicit operator OrderId(int id) => new(id);
    }

    public record OrderNumber : String100
    {
        public OrderNumber(string value) : base(value) { }

        public static explicit operator string(OrderNumber id) => id.Value;
        public static explicit operator OrderNumber(string id) => new(id);
    }

    public class Order
    {
        public Order(ClientId clientId)
        {
            OrderNumber = GenerateOrderName();
            ClientId = clientId;
            OrderLines = new List<OrderLine>();
        }

        public OrderId OrderId { get; set; }

        public OrderNumber OrderNumber { get; set; }
        public ClientId ClientId { get; set; }
        public List<OrderLine> OrderLines { get; set; }

        public void AddOrderLine(PositiveNumber quantityId, ProductId productId)
        {
            OrderLines.Add(new OrderLine(productId, quantityId));
        }

        private OrderNumber GenerateOrderName() => (OrderNumber) $"Order-{DateTime.Now.ToShortDateString()}"; //OrderName = Order-19.12.2022
    }

    public record OrderLineId : Id
    {
        public OrderLineId(int id) : base(id) { }

        public static explicit operator int(OrderLineId id) => id.Value;
        public static explicit operator OrderLineId(int id) => new(id);
    }

    public class OrderLine
    {
        public OrderLine(ProductId productId, PositiveNumber quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public OrderLineId OrderLineId { get; set; }
        public ProductId ProductId { get; set; }
        public PositiveNumber Quantity { get; set; }
    }

    public record ProductId : Id
    {
        public ProductId(int id) : base(id) { }

        public static explicit operator int(ProductId id) => id.Value;
        public static explicit operator ProductId(int id) => new(id);
    }

    public record ProductName : String100
    {
        public ProductName(string value) : base(value) { }

        public static explicit operator string(ProductName id) => id.Value;
        public static explicit operator ProductName(string id) => new(id);
    }

    public class Product
    {
        public Product(ProductName productName)
        {
            ProductName = productName;
        }

        public ProductId ProductId { get; set; }
        public String100 ProductName { get; set; }
    }

        public ProductId ProductId { get; set; }
        public ProductName ProductName { get; set; }
    }

    public record ClientId : Id
    {
        public ClientId(int id) : base(id) { }

        public static explicit operator int(ClientId id) => id.Value;
        public static explicit operator ClientId(int id) => new(id);
    }

    public record ClientName : String100
    {
        public ClientName(string value) : base(value) { }

        public static explicit operator string(ClientName id) => id.Value;
        public static explicit operator ClientName(string id) => new(id);
    }

    public class Client
    {
        public Client(ClientName clientName, Email email)
        {
            ClientName = clientName;
            Email = email;
        }

        public ClientId ClientId { get; set; }
        public ClientName ClientName { get; set; }   
        public Email Email { get; set; }
    }
}
