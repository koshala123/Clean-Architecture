using MediatR;

namespace AaronTicket.TicketManagment.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest<Unit>
    {
        public Guid EventId { get; set; }
    }
}
