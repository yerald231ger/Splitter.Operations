namespace Splitter.Operations.WebApi;

public record GetVouchersDto : ResponseManyDto<VoucherDto>
{
    public GetVouchersDto(Guid? commandId, IEnumerable<VoucherDto> items)
    {
        this.items = items;
        this.commandId = commandId;
    }
}
