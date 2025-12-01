using EventHub.Application.DTOs;
using EventHub.Application.Exceptions;
using EventHub.Application.Interfaces;
using EventHub.Domain.Entities;

namespace EventHub.Application.Services;

public class RegistrationService : IRegistrationService
{
    private readonly IRegistrationRepository _registrationRepo;
    private readonly IEventRepository _eventRepo;
    private readonly IParticipantRepository _participantRepo;

    public RegistrationService(
        IRegistrationRepository registrationRepo,
        IEventRepository eventRepo,
        IParticipantRepository participantRepo)
    {
        _registrationRepo = registrationRepo;
        _eventRepo = eventRepo;
        _participantRepo = participantRepo;
    }

    public async Task<RegistrationDto> RegisterAsync(CreateRegistrationRequest request)
    {
        var ev = await _eventRepo.GetByIdAsync(request.EventId);
        if (ev == null)
            throw new NotFoundException($"Event with ID {request.EventId} not found");

        var participant = await _participantRepo.GetByIdAsync(request.ParticipantId);
        if (participant == null)
            throw new NotFoundException($"Participant with ID {request.ParticipantId} not found");

        var registration = new Registration(ev.Id, participant.Id);

        await _registrationRepo.AddAsync(registration);
        await _registrationRepo.SaveChangesAsync();

        return new RegistrationDto
        {
            Id = registration.Id,
            EventId = registration.EventId,
            ParticipantId = registration.ParticipantId,
            RegisteredAtUtc = registration.RegisteredAtUtc
        };
    }

    public async Task<IEnumerable<RegistrationDto>> GetRegistrationsForEventAsync(Guid eventId)
    {
        var all = await _registrationRepo.GetAllAsync();

        return all
            .Where(r => r.EventId == eventId)
            .Select(r => new RegistrationDto
            {
                Id = r.Id,
                EventId = r.EventId,
                ParticipantId = r.ParticipantId,
                RegisteredAtUtc = r.RegisteredAtUtc
            });
    }
}
