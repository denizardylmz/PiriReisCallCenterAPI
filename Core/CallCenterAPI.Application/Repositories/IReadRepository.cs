using System.Linq.Expressions;
using CallCenterAPI.Domain.Entities.Common;

namespace CallCenterAPI.Application.Repositories;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
    public IQueryable<T> GetAll (bool Tracking = true);
    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool Tracking = true);

    public Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool Tracking = true);
    public Task<T> GetByIdAsync(string id, bool Tracking = true);

}