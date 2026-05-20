using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;

public class GetCategoriesListQueryHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository) : IRequestHandler<GetCategoriesListQuery, List<CategoryListVm>>
{
    private readonly IAsyncRepository<Category> _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<CategoryListVm>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
    {
        var allCategories = (await _categoryRepository.ListAllAsync()).OrderBy(x => x.Name);
        return _mapper.Map<List<CategoryListVm>>(allCategories);
    }
}