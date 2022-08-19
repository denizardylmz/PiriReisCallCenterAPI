using CallCenterAPI.Application.CQRS.Commands.Request;
using CallCenterAPI.Application.CQRS.Commands.Response;
using CallCenterAPI.Application.Repositories.CallRecordRep;
using MediatR;

namespace CallCenterAPI.Application.CQRS.Handlers.CommandHandlers;

public class UpdateCallRecordCommandHandler: IRequestHandler<UpdateCallRecordCommandRequest,UpdateCallRecordCommandResponse>
{
    private readonly ICallRecordWriteRepository _callRecordWriteRepository;

    public UpdateCallRecordCommandHandler(ICallRecordWriteRepository recordWriteRepository)
    {
        _callRecordWriteRepository = recordWriteRepository;
    }

    public async Task<UpdateCallRecordCommandResponse> Handle(UpdateCallRecordCommandRequest request, CancellationToken cancellationToken)
    {

        try
        {
            var result = _callRecordWriteRepository.Update(request.CallRecord);
            await _callRecordWriteRepository.SaveAsync();
            
            return new UpdateCallRecordCommandResponse() { IsSuccess = result };   
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception occurs : {e}");
            return new UpdateCallRecordCommandResponse() { IsSuccess = false };
        }
        

        
    }
}