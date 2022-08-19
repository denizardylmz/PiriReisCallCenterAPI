using CallCenterAPI.Domain.Entities.Common;

namespace CallCenterAPI.Application.Repositories;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
{
    Task<bool> AddAsync(T model);
    Task<bool> AddRange(List<T> datas);
    Task<bool> Remove(string id);
    bool Remove(T Model);
    bool Update(T model);
    Task<int> SaveAsync();
}