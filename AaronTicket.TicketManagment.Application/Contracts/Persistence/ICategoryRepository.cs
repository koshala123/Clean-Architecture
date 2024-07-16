using AaronTicket.TicketManagment.Domain.Entities;

namespace AaronTicket.TicketManagment.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents);
    }
}
