using AaronTicket.TicketManagment.Application.Contracts.Infastructure;
using AaronTicket.TicketManagment.Application.Contracts.Persistence;
using AaronTicket.TicketManagment.Application.Models.Mail;
using AaronTicket.TicketManagment.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AaronTicket.TicketManagment.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        public CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository, IEmailService emailService)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _emailService = emailService;
        }
        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var @event = _mapper.Map<Event>(request);

            var validator = new CreateEventCommandValidator(_eventRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new Exceptions.ValidationException(validationResult);
            }

            @event = await _eventRepository.AddAsync(@event);

            var email = new Email() { Body = $"A new event was created: {request}", Subject = "A new event was created", To = "aaronfernando.edu@hotmail.com" };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                //Log if it fails.
            }

            return @event.EventId;
        }
    }
}
