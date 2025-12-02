using EventHub.Domain.Entities;

namespace EventHub.Domain.Tests;

public class RegistrationTests
{
    [Fact]
    public void Constructor_SetsPropertiesAndTimestamp()
    {
        var eventId = Guid.NewGuid();
        var participantId = Guid.NewGuid();

        var registration = new Registration(eventId, participantId);

        Assert.Equal(eventId, registration.EventId);
        Assert.Equal(participantId, registration.ParticipantId);
        Assert.True((DateTime.UtcNow - registration.RegisteredAtUtc).TotalSeconds < 5);
    }
}
