using CallCenterAPI.Application.CQRS.Commands.Request;
using CallCenterAPI.Application.Repositories.CallRecordRep;
using MediatR;

namespace CallCenterAPI.Application.CQRS.Handlers.CommandHandlers;

public class DeleteCallRecordHandler : IRequestHandler<DeleteCallRecordCommandRequest, DeleteCallRecordCommandResponse>
{

    private readonly ICallRecordWriteRepository _callRecordWriteRepository;
    public DeleteCallRecordHandler(ICallRecordWriteRepository callRecordWriteRepository)
    {
        _callRecordWriteRepository = callRecordWriteRepository;
    }

    public async Task<DeleteCallRecordCommandResponse> Handle(DeleteCallRecordCommandRequest request, CancellationToken cancellationToken)
    {
        bool result = await _callRecordWriteRepository.Remove(request.Id);
        await _callRecordWriteRepository.SaveAsync();

        return new DeleteCallRecordCommandResponse() { IsSuccess = result };
    }
}