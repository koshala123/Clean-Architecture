using AaronTicket.TicketManagment.Domain.Entities;

namespace AaronTicket.TicketManagment.Application.Contracts.Persistence
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
        Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate);
    }
}
