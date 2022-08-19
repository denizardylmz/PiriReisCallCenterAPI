using CallCenterAPI.Application.CQRS.Commands.Request;
using CallCenterAPI.Application.CQRS.Commands.Response;
using CallCenterAPI.Application.Repositories;
using CallCenterAPI.Application.Repositories.CallRecordRep;
using CallCenterAPI.Domain.Entities;
using MediatR;

namespace CallCenterAPI.Application.CQRS.Handlers.CommandHandlers;

public class CreateCallRecordCommandHandler : IRequestHandler<CreateCallRecordCommandRequest, CreateCallRecordCommandResponse>
{
    private readonly ICallRecordWriteRepository _callRecordWrite;
    
    public CreateCallRecordCommandHandler(ICallRecordWriteRepository writeRepository)
    {
        _callRecordWrite = writeRepository;
    }


    public async Task<CreateCallRecordCommandResponse> Handle(CreateCallRecordCommandRequest request,
        CancellationToken cancellationToken)
    {
         bool result = await _callRecordWrite.AddAsync(new CallRecord()
        {
            Gender = request.Gender,
            Duration = request.Duration,
            Subject = request.Subject
        });
         await _callRecordWrite.SaveAsync();

         return new CreateCallRecordCommandResponse() { IsSuccess = result };
    }


}