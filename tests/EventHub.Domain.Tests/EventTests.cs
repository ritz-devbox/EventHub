using EventHub.Domain.Entities;
using EventHub.Domain.Exceptions;

namespace EventHub.Domain.Tests;

public class EventTests
{
    [Fact]
    public void Constructor_WithValidData_SetsProperties()
    {
        var start = DateTime.UtcNow.AddHours(1);
        var end = start.AddHours(2);

        var @event = new Event("Launch", "Product launch", start, end, "Online");

        Assert.Equal("Launch", @event.Title);
        Assert.Equal("Product launch", @event.Description);
        Assert.Equal(start, @event.StartTimeUtc);
        Assert.Equal(end, @event.EndTimeUtc);
        Assert.Equal("Online", @event.Location);
        Assert.True((DateTime.UtcNow - @event.CreatedAtUtc).TotalSeconds < 5);
    }

    [Fact]
    public void Constructor_WithEndBeforeStart_Throws()
    {
        var start = DateTime.UtcNow.AddHours(2);
        var end = start.AddHours(-1);

        Assert.Throws<InvalidEventException>(() => new Event("Title", "Description", start, end, "Room 1"));
    }

    [Fact]
    public void Update_WithValidData_ChangesProperties()
    {
        var start = DateTime.UtcNow.AddHours(1);
        var end = start.AddHours(2);
        var @event = new Event("Original", "Description", start, end, "Room 1");

        var newStart = start.AddDays(1);
        var newEnd = newStart.AddHours(3);

        @event.Update("Updated", "New description", newStart, newEnd, "Room 42");

        Assert.Equal("Updated", @event.Title);
        Assert.Equal("New description", @event.Description);
        Assert.Equal(newStart, @event.StartTimeUtc);
        Assert.Equal(newEnd, @event.EndTimeUtc);
        Assert.Equal("Room 42", @event.Location);
    }
}
