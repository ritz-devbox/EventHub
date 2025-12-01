using EventHub.Application.Services;
using EventHub.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EventHub.Api.Extensions;

public static class ApiDependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IParticipantService, ParticipantService>();
        services.AddScoped<IRegistrationService, RegistrationService>();

        return services;
    }
}
