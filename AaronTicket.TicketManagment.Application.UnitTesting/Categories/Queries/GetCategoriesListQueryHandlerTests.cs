using AaronTicket.TicketManagment.Application.Contracts.Persistence;
using AaronTicket.TicketManagment.Application.Features.Categories.Queries.GetCategoriesList;
using AaronTicket.TicketManagment.Application.Profiles;
using AaronTicket.TicketManagment.Application.UnitTesting.Mocks;
using AaronTicket.TicketManagment.Domain.Entities;
using AutoMapper;
using Moq;
using Shouldly;

namespace AaronTicket.TicketManagment.Application.UnitTesting.Categories.Queries
{
    public class GetCategoriesListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;

        public GetCategoriesListQueryHandlerTests()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetCategoriesListTest()
        {
            var handler = new GetCategoriesListQueryHandler(_mapper, _mockCategoryRepository.Object);

            var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<CategoryListVm>>();

            result.Count.ShouldBe(4);
        }
    }
}
