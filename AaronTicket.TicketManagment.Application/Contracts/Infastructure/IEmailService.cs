using AaronTicket.TicketManagment.Application.Models.Mail;

namespace AaronTicket.TicketManagment.Application.Contracts.Infastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
