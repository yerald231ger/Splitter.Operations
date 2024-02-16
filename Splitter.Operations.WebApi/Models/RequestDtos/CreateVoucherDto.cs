namespace Splitter.Operations.WebApi;

public record CreateVoucherDto : RequestDto
{
    public decimal Amount { get; set; }
    public int Tip { get; set; }
    public bool IsPartialPayment { get; set; }
}
