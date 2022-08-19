using CallCenterAPI.Application.CQRS.Query.Response;
using MediatR;

namespace CallCenterAPI.Application.CQRS.Query.Request;

public class GetByIdCallRecordsQueryRequest : IRequest<GetByIdCallRecordsQueryResponse>
{
    public string Id { get; set; }
    public bool Tracking { get; set; } = true;
}