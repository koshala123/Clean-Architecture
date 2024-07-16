using AaronTicket.TicketManagment.Application.Features.Events.Queries.GetEventsExport;

namespace AaronTicket.TicketManagment.Application.Contracts.Infastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
