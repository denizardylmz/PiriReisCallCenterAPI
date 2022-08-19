using CallCenterAPI.Domain.Entities;

namespace CallCenterAPI.Application.CQRS.Query.Response;

public class GetAllCallRecordsQueryResponse
{
    public bool IsSuccess { get; set; }
    public IQueryable<CallRecord> CallRecords { get; set; }
}