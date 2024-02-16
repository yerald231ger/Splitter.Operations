using Splitter.Operations.Models;

namespace Splitter.Operations.WebApi;

#pragma warning disable IDE1006 // Naming Styles
public record EventTableDto(Guid commandId, Guid id, string name, DateTime createdAt) : ReponseDto(commandId);
#pragma warning restore IDE1006 // Naming Styles