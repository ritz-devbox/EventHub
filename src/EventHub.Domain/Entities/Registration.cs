using EventHub.Domain.Common;

namespace EventHub.Domain.Entities;

public class Registration : EntityBase
{
    public Guid EventId { get; private set; }
    public Guid ParticipantId { get; private set; }
    public DateTime RegisteredAtUtc { get; private set; }

    private Registration() { }

    public Registration(Guid eventId, Guid participantId)
    {
        EventId = eventId;
        ParticipantId = participantId;
        RegisteredAtUtc = DateTime.UtcNow;
    }
}
