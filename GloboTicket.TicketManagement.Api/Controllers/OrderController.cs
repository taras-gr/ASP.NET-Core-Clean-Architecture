using GloboTicket.TicketManagement.Application.Features.Orders.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.TicketManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("/getpagedordersformonth", Name = "GetPagedOrdersForMonth")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<PagedOrdersForMonthVm>> GetPagedOrdersForMonth(DateTime date, int page, int size)
    {
        var getOrdersForMonthQuery = new GetOrdersForMonthQuery() { Date = date, Page = page, Size = size };
        var dtos = await _mediator.Send(getOrdersForMonthQuery);

        return Ok(dtos);
    }
}