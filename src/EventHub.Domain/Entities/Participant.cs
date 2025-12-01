using EventHub.Domain.Common;
using EventHub.Domain.ValueObjects;

namespace EventHub.Domain.Entities;

public class Participant : EntityBase
{
    public string Name { get; private set; }
    public Email Email { get; private set; }

    private Participant() { }

    public Participant(string name, Email email)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Participant name cannot be empty.");

        Name = name;
        Email = email;
    }
}
