using OrderMakerApp.Commands;
using OrderMakerApp.Domain;
using OrderMakerApp.Repositories;
using OrderMakerApp.Validators;

namespace OrderMakerApp.Services
{
    public class OrderService
    {
        private readonly ClientService clientService;
        private readonly OrderRepository repository;

        public OrderService(ClientService clientService, OrderRepository repository)
        {
            this.clientService = clientService;
            this.repository = repository;
        }

        public void MakeOrder(NewOrderCommand command)
        {
            Client client = clientService.GetOrCreateClient(command.ClientName);

            var order = new Order(client.ClientId);

            foreach (var (productId, quantity) in command.OrderedProducts)
                order.AddOrderLine((PositiveNumber)quantity, (ProductId)productId);

            new OrderValidator().Validate(order);

            repository.Save(order);
        }
    }
}
