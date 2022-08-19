using CallCenterAPI.Domain.Entities.Common;

namespace CallCenterAPI.Domain.Entities;

public class CallRecord : BaseEntity
{
    public Gender Gender { get; set; }
    public Duration Duration { get; set; }
    public Subject Subject { get; set; }
    
}


public enum Gender
{
    Male,
    Female
}

public enum Duration
{
    OneToFive,
    FiveToTen,
    TenToMore
}

public enum Subject
{
    Administrative,
    Academic,
    Information,
    Other
}