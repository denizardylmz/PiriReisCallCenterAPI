using CallCenterAPI.Domain.Entities;

namespace CallCenterAPI.Application.ViewModels;

public class vm_CallRecordCreate
{
    public Gender Gender { get; set; }
    public Duration Duration { get; set; }
    public Subject Subject { get; set; }
}