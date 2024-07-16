using AaronTicket.TicketManagment.Application.Contracts.Infastructure;
using AaronTicket.TicketManagment.Application.Models.Mail;
using AaronTicket.TicketManagment.Infrastructure.FileExport;
using AaronTicket.TicketManagment.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AaronTicket.TicketManagment.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ICsvExporter, CsvExporter>();

            return services;
        }
    }
}
