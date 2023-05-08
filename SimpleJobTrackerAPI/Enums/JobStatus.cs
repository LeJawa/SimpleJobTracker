namespace SimpleJobTrackerAPI.Enums
{
    public enum JobStatus
    {
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
