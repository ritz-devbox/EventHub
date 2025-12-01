using EventHub.Application.DTOs;

namespace EventHub.Application.Interfaces;

public interface IRegistrationService
{
    Task<RegistrationDto> RegisterAsync(CreateRegistrationRequest request);
    Task<IEnumerable<RegistrationDto>> GetRegistrationsForEventAsync(Guid eventId);
}
