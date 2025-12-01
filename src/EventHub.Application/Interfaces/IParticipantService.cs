using EventHub.Application.DTOs;

namespace EventHub.Application.Interfaces;

public interface IParticipantService
{
    Task<ParticipantDto> CreateParticipantAsync(CreateParticipantRequest request);
    Task<ParticipantDto> GetParticipantByIdAsync(Guid id);
}
