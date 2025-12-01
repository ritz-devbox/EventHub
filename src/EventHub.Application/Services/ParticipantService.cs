using EventHub.Application.DTOs;
using EventHub.Application.Exceptions;
using EventHub.Application.Interfaces;
using EventHub.Domain.Entities;
using EventHub.Domain.ValueObjects;

namespace EventHub.Application.Services;

public class ParticipantService : IParticipantService
{
    private readonly IParticipantRepository _repo;

    public ParticipantService(IParticipantRepository repo)
    {
        _repo = repo;
    }

    public async Task<ParticipantDto> CreateParticipantAsync(CreateParticipantRequest request)
    {
        var participant = new Participant(
            request.Name,
            new Email(request.Email)
        );

        await _repo.AddAsync(participant);
        await _repo.SaveChangesAsync();

        return new ParticipantDto
        {
            Id = participant.Id,
            Name = participant.Name,
            Email = participant.Email.Value
        };
    }

    public async Task<ParticipantDto> GetParticipantByIdAsync(Guid id)
    {
        var participant = await _repo.GetByIdAsync(id);
        if (participant == null)
            throw new NotFoundException($"Participant with ID {id} not found");

        return new ParticipantDto
        {
            Id = participant.Id,
            Name = participant.Name,
            Email = participant.Email.Value
        };
    }
}
