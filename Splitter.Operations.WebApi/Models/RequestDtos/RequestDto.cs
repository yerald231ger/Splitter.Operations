namespace Splitter.Operations.WebApi;

public abstract record RequestDto
{
    public Guid CommandId { get; set; } = Guid.NewGuid();
}
