namespace Splitter.Extentions.Interface.Abstractions;
public class SptRejection<TCode> : SptResult
    where TCode : notnull, Enum
{
    public TCode RejectionCode { get; set; }
    public string? Message { get; set; }
    public SptRejection(Guid commandId, TCode rejectionCode, string? message)
       : base(commandId)
    {
        RejectionCode = rejectionCode;
        Message = message;
    }
 
    public SptRejection()
    {
        RejectionCode = default!;
        Message = default!;
    }

}
