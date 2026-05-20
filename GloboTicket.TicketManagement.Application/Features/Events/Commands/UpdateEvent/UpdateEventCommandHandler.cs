using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;

public class UpdateEventCommandHandler(IMapper mapper, IAsyncRepository<Event> eventRepository) : IRequestHandler<UpdateEventCommand>
{
    private readonly IAsyncRepository<Event> _eventRepository = eventRepository;
    private readonly IMapper _mapper = mapper;

    public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {

        var eventToUpdate = await _eventRepository.GetByIdAsync(request.EventId);

        _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));

        await _eventRepository.UpdateAsync(eventToUpdate);
    }
}