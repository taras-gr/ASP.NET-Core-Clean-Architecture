using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;

public class GetCategoriesListWithEventsQueryHandler(IMapper mapper, ICategoryRepository categoryRepository) : IRequestHandler<GetCategoriesListWithEventsQuery, List<CategoryEventListVm>>
{
    private readonly IMapper _mapper = mapper;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<List<CategoryEventListVm>> Handle(GetCategoriesListWithEventsQuery request, CancellationToken cancellationToken)
    {
        var list = await _categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);
        return _mapper.Map<List<CategoryEventListVm>>(list);
    }
}