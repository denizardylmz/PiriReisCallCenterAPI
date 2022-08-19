using CallCenterAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace CallCenterAPI.Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}