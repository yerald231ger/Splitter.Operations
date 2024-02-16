namespace Splitter.Operations.WebApi;

public abstract class RequestDto
{
    public Guid CommandId { get; set; } = Guid.NewGuid();
}
