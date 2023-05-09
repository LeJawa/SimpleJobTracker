namespace SimpleJobTrackerAPI.Enums
{
    public enum JobStatus
    {
        Undefined = 0,
        NotYetApplied,
        AppliedWaitingForFirstContact,
        FirstContactMadeWaitingForCall,
        WaitingForCallBack,
        WaitingForTechnicalInterview,        
        RejectedByCompany,
        RejectedByMe,
        Other,
        GotTheJob,
    }
}
