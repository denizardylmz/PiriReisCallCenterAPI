using CallCenterAPI.Application.Repositories;
using CallCenterAPI.Domain.Entities.Common;
using CallCenterAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CallCenterAPI.Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
{
    private readonly CallCenterContext _context;
    public WriteRepository(CallCenterContext context)
    {
        _context = context;
    }
    
    
    public DbSet<T> Table => _context.Set<T>();
    
    
    public async Task<bool> AddAsync(T model)
    {
        EntityEntry<T> entityEntry = await Table.AddAsync(model);
        return entityEntry.State == EntityState.Added;
    }

    public async Task<bool> AddRange(List<T> datas)
    {
        await Table.AddRangeAsync(datas);
        return true;
    }

    public async Task<bool> Remove(string id)
    {
        T model = await Table.FirstOrDefaultAsync(Data => Data.Id == Guid.Parse(id));
        return Remove(model);
    }

    public bool Remove(T Model)
    {
        EntityEntry<T> entity = Table.Remove(Model);
        return entity.State == EntityState.Deleted;
    }

    public bool Update(T model)
    {
        EntityEntry<T> entityEntry = Table.Update(model);

        return entityEntry.State == EntityState.Modified;
    }

    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

}