using EventHub.Domain.Common;
using EventHub.Domain.Exceptions;

namespace EventHub.Domain.Entities;

public class Event : EntityBase
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime StartTimeUtc { get; private set; }
    public DateTime EndTimeUtc { get; private set; }
    public string Location { get; private set; }
    public DateTime CreatedAtUtc { get; private set; }

    private Event() { }

    public Event(string title, string description, DateTime startUtc, DateTime endUtc, string location)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new InvalidEventException("Event title cannot be empty.");

        if (endUtc <= startUtc)
            throw new InvalidEventException("Event end time must be after the start time.");

        Title = title;
        Description = description;
        StartTimeUtc = startUtc;
        EndTimeUtc = endUtc;
        Location = location;
        CreatedAtUtc = DateTime.UtcNow;
    }

    public void Update(string title, string description, DateTime startUtc, DateTime endUtc, string location)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new InvalidEventException("Event title cannot be empty.");

        if (endUtc <= startUtc)
            throw new InvalidEventException("Event end time must be after the start time.");

        Title = title;
        Description = description;
        StartTimeUtc = startUtc;
        EndTimeUtc = endUtc;
        Location = location;
    }
}
