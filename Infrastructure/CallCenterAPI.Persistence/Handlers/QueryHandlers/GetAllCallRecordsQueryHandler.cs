using CallCenterAPI.Application.CQRS.Query.Request;
using CallCenterAPI.Application.CQRS.Query.Response;
using CallCenterAPI.Application.Repositories.CallRecordRep;
using CallCenterAPI.Domain.Entities;
using MediatR;

namespace CallCenterAPI.Persistence.Handlers.QueryHandlers;

public class GetAllCallRecordsQueryHandler : IRequestHandler<GetAllCallRecordsQueryRequest, GetAllCallRecordsQueryResponse>
{

    private readonly ICallRecordReadRepository _recordReadRepository;

    public GetAllCallRecordsQueryHandler(ICallRecordReadRepository recordReadRepository)
    {
        _recordReadRepository = recordReadRepository;
    }

    public async  Task<GetAllCallRecordsQueryResponse> Handle(GetAllCallRecordsQueryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            IQueryable<CallRecord> records =  _recordReadRepository.GetAll(request.Tracking);
            return new GetAllCallRecordsQueryResponse() { IsSuccess = true, CallRecords = records };
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception occurs : {e}");
            return new GetAllCallRecordsQueryResponse() { IsSuccess = false };
        }
        
    }
}