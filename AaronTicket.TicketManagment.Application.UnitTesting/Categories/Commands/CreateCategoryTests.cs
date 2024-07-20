using AaronTicket.TicketManagment.Application.Contracts.Persistence;
using AaronTicket.TicketManagment.Application.Features.Categories.Commands.CreateCategory;
using AaronTicket.TicketManagment.Application.Profiles;
using AaronTicket.TicketManagment.Application.UnitTesting.Mocks;
using AaronTicket.TicketManagment.Domain.Entities;
using AutoMapper;
using Moq;
using Shouldly;

namespace AaronTicket.TicketManagment.Application.UnitTesting.Categories.Commands
{
    public class CreateCategoryTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;

        public CreateCategoryTests()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidCategory_AddedToCategoriesRepo()
        {
            var handler = new CreateCategoryCommandHandler(_mapper, _mockCategoryRepository.Object);

            await handler.Handle(new CreateCategoryCommand() { Name = "Test" }, CancellationToken.None);

            var allCategories = await _mockCategoryRepository.Object.ListAllAsync();
            allCategories.Count.ShouldBe(5);
        }
    }
}
