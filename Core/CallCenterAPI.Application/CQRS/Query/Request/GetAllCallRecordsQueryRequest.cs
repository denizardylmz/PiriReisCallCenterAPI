using CallCenterAPI.Application.CQRS.Query.Response;
using MediatR;

namespace CallCenterAPI.Application.CQRS.Query.Request;

public class GetAllCallRecordsQueryRequest : IRequest<GetAllCallRecordsQueryResponse>
{
    public bool Tracking { get; set; } = true;
}