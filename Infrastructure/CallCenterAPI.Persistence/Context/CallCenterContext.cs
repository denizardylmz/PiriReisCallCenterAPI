using CallCenterAPI.Domain.Entities;
using CallCenterAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace CallCenterAPI.Persistence.Context;

public class CallCenterContext : DbContext
{
    public CallCenterContext(DbContextOptions options): base(options){}
    
    public DbSet<CallRecord> CallRecords { get; set; }


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var datas =  ChangeTracker.Entries<BaseEntity>();

        foreach (var data in datas)
        {
            _ = data.State switch
            {
                EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                _ => DateTime.UtcNow
            };
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}