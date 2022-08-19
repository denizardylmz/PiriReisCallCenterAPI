using CallCenterAPI.Application.Repositories.CallRecordRep;
using CallCenterAPI.Domain.Entities;
using CallCenterAPI.Persistence.Context;

namespace CallCenterAPI.Persistence.Repositories.CallRecordRep;

public class CallRecordReadRepository : ReadRepository<CallRecord> , ICallRecordReadRepository
{
    public CallRecordReadRepository(CallCenterContext context) : base(context)
    {
    }
}