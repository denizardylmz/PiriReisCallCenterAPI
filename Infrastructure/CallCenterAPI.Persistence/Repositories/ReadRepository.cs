using System.Linq.Expressions;
using CallCenterAPI.Application.Repositories;
using CallCenterAPI.Domain.Entities.Common;
using CallCenterAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CallCenterAPI.Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly CallCenterContext _context;


    public ReadRepository(CallCenterContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();
    
    
    public IQueryable<T> GetAll(bool tracking = true)
    {
        var query = Table.AsQueryable();
        
        if (!tracking)
        {
            query.AsNoTracking();
        }
        return query;
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.Where(method);
        if (!tracking)
        {
            query.AsNoTracking();
        }

        return query;
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
        {
            query.AsNoTracking();
        }
        return await query.SingleOrDefaultAsync(method);
    }

    public async Task<T> GetByIdAsync(string id, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
        {
            query.AsNoTracking();
        }
        return await query.SingleOrDefaultAsync(data => data.Id == Guid.Parse(id));
    }
}