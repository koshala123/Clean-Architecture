using MediatR;

namespace AaronTicket.TicketManagment.Application.Features.Events.Queries.GetEventList
{
    public class GetEventsListQuery : IRequest<List<EventListVm>>
    {

    }
}
