using Splitter.Extentions.Interface.Abstractions;

namespace Splitter.Operations.Interface;

public class CreateCommensalityCommand : SptCommand
{
    public required Guid CommensalityId { get; set; }
    public required string Name { get; set; }
}
