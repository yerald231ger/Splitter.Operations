namespace Splitter.Commensality.WebApi;

public record GetVouchersDto : ResponseManyDto<VoucherDto>
{
    public GetVouchersDto(Guid? commandId, IEnumerable<VoucherDto> items)
    {
        this.items = items;
        CommandId = commandId;
    }
}
