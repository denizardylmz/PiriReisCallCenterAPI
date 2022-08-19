using CallCenterAPI.Application.CQRS.Query.Request;
using CallCenterAPI.Application.CQRS.Query.Response;
using CallCenterAPI.Application.Repositories.CallRecordRep;
using CallCenterAPI.Domain.Entities;
using MediatR;

namespace CallCenterAPI.Persistence.Handlers.QueryHandlers;

public class GetByIdRecordsQueryHandler : IRequestHandler<GetByIdCallRecordsQueryRequest, GetByIdCallRecordsQueryResponse>
{
    private readonly ICallRecordReadRepository _recordReadRepository;

    public GetByIdRecordsQueryHandler(ICallRecordReadRepository recordReadRepository)
    {
        _recordReadRepository = recordReadRepository;
    }

    public async Task<GetByIdCallRecordsQueryResponse> Handle(GetByIdCallRecordsQueryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            CallRecord callRecord = await _recordReadRepository.GetByIdAsync(request.Id, request.Tracking);
            return new GetByIdCallRecordsQueryResponse() { IsSuccess = true, CallRecord = callRecord };
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception occurs : e");
            return new GetByIdCallRecordsQueryResponse() { IsSuccess = false };
        }
        
    }
}