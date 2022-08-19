using CallCenterAPI.Application.Repositories.CallRecordRep;
using CallCenterAPI.Domain.Entities;
using CallCenterAPI.Persistence.Context;

namespace CallCenterAPI.Persistence.Repositories.CallRecordRep;

public class CallRecordWriteRepository : WriteRepository<CallRecord> , ICallRecordWriteRepository 
{
    public CallRecordWriteRepository(CallCenterContext context) : base(context)
    {
    }
}