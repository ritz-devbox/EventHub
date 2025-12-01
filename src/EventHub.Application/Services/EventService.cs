using EventHub.Application.DTOs;
using EventHub.Application.Exceptions;
using EventHub.Application.Interfaces;
using EventHub.Domain.Entities;

namespace EventHub.Application.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _repository;

    public EventService(IEventRepository repository)
    {
        _repository = repository;
    }

    public async Task<EventDto> CreateEventAsync(CreateEventRequest request)
    {
        var entity = new Event(
            request.Title,
            request.Description,
            request.StartTimeUtc,
            request.EndTimeUtc,
            request.Location
        );

        await _repository.AddAsync(entity);
        return ToDto(entity);
    }

    public async Task<EventDto> GetEventByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id)
            ?? throw new NotFoundException($"Event {id} not found.");

        return ToDto(entity);
    }

    public async Task<IEnumerable<EventDto>> GetAllEventsAsync()
    {
        var events = await _repository.GetAllAsync();
        return events.Select(ToDto);
    }

    public async Task<EventDto> UpdateEventAsync(Guid id, UpdateEventRequest request)
    {
        var entity = await _repository.GetByIdAsync(id)
            ?? throw new NotFoundException($"Event {id} not found.");

        // Apply updates via domain entity method or directly
        entity.Update(
            request.Title,
            request.Description,
            request.StartTimeUtc,
            request.EndTimeUtc,
            request.Location
        );

        await _repository.SaveChangesAsync();

        return ToDto(entity);
    }

    public async Task DeleteEventAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id)
            ?? throw new NotFoundException($"Event {id} not found.");

        await _repository.RemoveAsync(entity);
        await _repository.SaveChangesAsync();
    }

    private static EventDto ToDto(Event e) => new()
    {
        Id = e.Id,
        Title = e.Title,
        Description = e.Description,
        Location = e.Location,
        StartTimeUtc = e.StartTimeUtc,
        EndTimeUtc = e.EndTimeUtc,
        CreatedAtUtc = e.CreatedAtUtc
    };
}
