using Splitter.Extensions.Interface.Abstractions;

namespace Splitter.Commensality.Interface;

public class CreateCommensalityCommand : SptCommand
{
    public required Guid CommensalityId { get; set; }
    public required string Name { get; set; }
}
