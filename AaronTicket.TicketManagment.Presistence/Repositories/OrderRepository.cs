using AaronTicket.TicketManagment.Application.Contracts.Persistence;
using AaronTicket.TicketManagment.Domain.Entities;

namespace AaronTicket.TicketManagment.Presistence.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(AaronTicketDbContext dbContext) : base(dbContext)
        {

        }
    }
}
