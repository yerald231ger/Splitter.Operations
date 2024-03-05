namespace Splitter.Extensions;

public abstract record RequestDto
{
    public Guid CommandId { get; set; } = Guid.NewGuid();
}