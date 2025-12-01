using EventHub.Application.DTOs;
using EventHub.Domain.Entities;

namespace EventHub.Application.Mappings;

public static class EventMapper
{
    public static EventDto ToDto(this Event ev) =>
        new()
        {
            Id = ev.Id,
            Title = ev.Title,
            Description = ev.Description,
            StartTimeUtc = ev.StartTimeUtc,
            EndTimeUtc = ev.EndTimeUtc,
            Location = ev.Location,
            CreatedAtUtc = ev.CreatedAtUtc
        };
}
