using EventHub.Domain.Entities;
using EventHub.Domain.ValueObjects;

namespace EventHub.Domain.Tests;

public class ParticipantTests
{
    [Fact]
    public void Constructor_WithValidData_SetsProperties()
    {
        var email = new Email("jane.doe@example.com");
        var participant = new Participant("Jane Doe", email);

        Assert.Equal("Jane Doe", participant.Name);
        Assert.Equal(email, participant.Email);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_WithEmptyName_Throws(string name)
    {
        var email = new Email("john@example.com");

        Assert.Throws<ArgumentException>(() => new Participant(name, email));
    }
}
