using AaronTicket.TicketManagment.Domain.Entities;

namespace AaronTicket.TicketManagment.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
    }
}
