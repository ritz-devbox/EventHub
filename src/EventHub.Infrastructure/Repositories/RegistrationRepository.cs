using EventHub.Application.Interfaces;
using EventHub.Domain.Entities;
using EventHub.Infrastructure.Persistence;

namespace EventHub.Infrastructure.Repositories;

public class RegistrationRepository : RepositoryBase<Registration>, IRegistrationRepository
{
    public RegistrationRepository(EventHubDbContext context) : base(context)
    {
    }
}
