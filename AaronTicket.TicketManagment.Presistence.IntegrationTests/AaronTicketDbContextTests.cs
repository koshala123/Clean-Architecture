using AaronTicket.TicketManagment.Application.Contracts;
using AaronTicket.TicketManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;

namespace AaronTicket.TicketManagment.Presistence.IntegrationTests
{
    public class AaronTicketDbContextTests
    {
        private readonly AaronTicketDbContext _aaronTicketDbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;

        public AaronTicketDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<AaronTicketDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _loggedInUserId = "0000000-0000-0000-0000-000000000000";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _aaronTicketDbContext = new AaronTicketDbContext(dbContextOptions, _loggedInUserServiceMock.Object);
        }

        [Fact]
        public async void Save_SetCreatedByProperty()
        {
            var ev = new Event() { EventId = Guid.NewGuid(), Name = "Test event" };

            _aaronTicketDbContext.Events.Add(ev);
            await _aaronTicketDbContext.SaveChangesAsync();

            ev.CreatedBy.ShouldBe(_loggedInUserId);
        }
    }
}
