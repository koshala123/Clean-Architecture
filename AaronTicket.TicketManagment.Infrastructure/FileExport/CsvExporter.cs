using AaronTicket.TicketManagment.Application.Contracts.Infastructure;
using AaronTicket.TicketManagment.Application.Features.Events.Queries.GetEventsExport;
using CsvHelper;
using System.Globalization;

namespace AaronTicket.TicketManagment.Infrastructure.FileExport
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                csvWriter.WriteRecords(eventExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
