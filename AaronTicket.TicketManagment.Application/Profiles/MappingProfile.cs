using AaronTicket.TicketManagment.Application.Features.Categories.Commands.CreateCategory;
using AaronTicket.TicketManagment.Application.Features.Categories.Queries.GetCategoriesList;
using AaronTicket.TicketManagment.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using AaronTicket.TicketManagment.Application.Features.Events.Commands.CreateEvent;
using AaronTicket.TicketManagment.Application.Features.Events.Commands.DeleteEvent;
using AaronTicket.TicketManagment.Application.Features.Events.Commands.UpdateEvent;
using AaronTicket.TicketManagment.Application.Features.Events.Queries.GetEventDetail;
using AaronTicket.TicketManagment.Application.Features.Events.Queries.GetEventList;
using AaronTicket.TicketManagment.Application.Features.Events.Queries.GetEventsExport;
using AaronTicket.TicketManagment.Domain.Entities;
using AutoMapper;

namespace AaronTicket.TicketManagment.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryListVm>().ReverseMap();
            CreateMap<Category, CategoryEventListVm>().ReverseMap();

            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, DeleteEventCommand>().ReverseMap();
        }
    }
}
