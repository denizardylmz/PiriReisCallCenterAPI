using CallCenterAPI.Domain.Entities;

namespace CallCenterAPI.Application.CQRS.Query.Response;

public class GetByIdCallRecordsQueryResponse
{
    public bool IsSuccess { get; set; }
    public CallRecord CallRecord { get; set; }
}