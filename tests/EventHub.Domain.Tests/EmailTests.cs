using EventHub.Domain.Exceptions;
using EventHub.Domain.ValueObjects;
using Xunit;

namespace EventHub.Domain.Tests;

public class EmailTests
{
    [Fact]
    public void Constructor_WithValidEmail_SetsValue()
    {
        var email = new Email("user@example.com");

        Assert.Equal("user@example.com", email.Value);
        Assert.Equal("user@example.com", email.ToString());
    }

    [Theory]
    [InlineData("")]
    [InlineData("invalid")]
    [InlineData("user@domain")]
    [InlineData("@example.com")]
    public void Constructor_WithInvalidEmail_Throws(string input)
    {
        Assert.Throws<InvalidEmailException>(() => new Email(input));
    }
}
