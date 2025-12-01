using EventHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EventHub.Infrastructure.Persistence;

public class EventHubDbContext : DbContext
{
    public EventHubDbContext(DbContextOptions<EventHubDbContext> options)
        : base(options)
    {
    }

    public DbSet<Event> Events => Set<Event>();
    public DbSet<Participant> Participants => Set<Participant>();
    public DbSet<Registration> Registrations => Set<Registration>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Example configurations (we can refine later)
        modelBuilder.Entity<Event>().Property(e => e.Title).IsRequired();

        // Value object configuration for Email
        modelBuilder.Entity<Participant>().OwnsOne(p => p.Email, owned =>
        {
            owned.Property(e => e.Value).HasColumnName("Email").IsRequired();
        });
    }
}
