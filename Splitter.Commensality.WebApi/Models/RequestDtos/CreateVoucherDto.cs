using Splitter.Extensions;

namespace Splitter.Commensality.WebApi;

public record CreateVoucherDto : RequestDto
{
    public Guid VoucherId { get; set; }
    public decimal Amount { get; set; }
    public int Tip { get; set; }
    public bool IsPartialPayment { get; set; }
}
