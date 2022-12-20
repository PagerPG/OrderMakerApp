using OrderMakerApp.Domain;

namespace OrderMakerApp.Validators
{
    public class OrderValidator
    {
        public void Validate(Order order)
        {
            if (order.OrderLines.Count == 0)
                throw new Exception("Order must have order lines.");
        }
    }   
}
