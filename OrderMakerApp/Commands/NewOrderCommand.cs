namespace OrderMakerApp.Commands
{
    public class NewOrderCommand
    {
        public object ClientName { get; internal set; }
        public List<(int ProductId, int Quantity)> OrderedProducts { get; internal set; }
    }
}