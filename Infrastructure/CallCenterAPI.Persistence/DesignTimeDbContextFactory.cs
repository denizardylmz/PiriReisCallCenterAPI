using CallCenterAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CallCenterAPI.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CallCenterContext>
{
    public CallCenterContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<CallCenterContext> dbContextOptionsBuilder =
            new DbContextOptionsBuilder<CallCenterContext>();

        dbContextOptionsBuilder.UseNpgsql(Configurations.ConnectionString);
        return new(dbContextOptionsBuilder.Options);
    }
}