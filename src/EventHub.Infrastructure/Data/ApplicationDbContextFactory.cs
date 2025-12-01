using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EventHub.Infrastructure.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        // Fallback connection string used ONLY at design-time
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=EventHubDb;Username=postgres;Password=UABRO");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
