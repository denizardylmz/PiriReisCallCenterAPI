using CallCenterAPI.Application.CQRS.Commands.Response;
using CallCenterAPI.Domain.Entities;
using MediatR;

namespace CallCenterAPI.Application.CQRS.Commands.Request;

public class CreateCallRecordCommandRequest : IRequest<CreateCallRecordCommandResponse>
{
    public Gender Gender { get; set; }
    public Duration Duration { get; set; }
    public Subject Subject { get; set; }
}