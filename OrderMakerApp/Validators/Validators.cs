using OrderMakerApp.Domain;

namespace OrderMakerApp.Validators
{
    public class OrderValidator
    {
        public void Validate(Order order)
        {
            if (string.IsNullOrEmpty(order.OrderNumber))
                throw new Exception("Order name can not be empty.");

            if (order.ClientId == 0)
                throw new Exception("Not valid ClientId.");

            if (order.OrderLines.Count == 0)
                throw new Exception("Order must have order lines.");

            var lineValidator = new OrderLineValidator();
            order.OrderLines.ForEach(lineValidator.Validate);
        }
    }

    public class OrderLineValidator
    {
        public void Validate(OrderLine orderLine)
        {
            if (orderLine.ProductId == 0)
                throw new Exception("Not valid ProductId.");

            if (orderLine.Quantity <= 0)
                throw new Exception("Not valid Quantity.");
        }
    }

    public class ProductValidator
    {
        public void Validate(Product product)
        {
            if (string.IsNullOrEmpty(product.ProductName))
                throw new Exception("Not valid ProductName.");

            if (product.ProductName.Length > 100)
                throw new Exception("Too long ProductName. Shoud has less that 100 chars.");
        }
    }

    public class ClientValidator
    {
        public void Validate(Client client)
        {
            ValidateName(client.ClientName);
            ValidateEmail(client.Email);
        }

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
