using System.Text.RegularExpressions;
using EventHub.Domain.Exceptions;

namespace EventHub.Domain.ValueObjects;

public record Email
{
    public string Value { get; }
    private static readonly Regex EmailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !EmailRegex.IsMatch(value))
            throw new InvalidEmailException("Invalid email format.");
        Value = value;
    }

    public override string ToString() => Value;
}