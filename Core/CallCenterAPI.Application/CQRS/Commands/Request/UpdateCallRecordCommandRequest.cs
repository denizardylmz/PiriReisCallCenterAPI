using CallCenterAPI.Application.CQRS.Commands.Response;
using CallCenterAPI.Domain.Entities;
using MediatR;

namespace CallCenterAPI.Application.CQRS.Commands.Request;

public class UpdateCallRecordCommandRequest : IRequest<UpdateCallRecordCommandResponse>
{
    public CallRecord CallRecord { get; set; }
    
}