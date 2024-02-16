using Microsoft.Identity.Client;
using Splitter.Operations.Models;

namespace Splitter.Operations.WebApi;

#pragma warning disable IDE1006 // Naming Styles
public record EventTableDto(Guid id, string name, DateTime createdAt)
{
    internal static EventTableDto ToDto(EventTable eventTable)
    => new(eventTable.Id, eventTable.Name, eventTable.CreatedAt);
}
#pragma warning restore IDE1006 // Naming Styles
