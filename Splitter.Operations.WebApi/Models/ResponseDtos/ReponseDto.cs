
using System.Text.Json.Serialization;

namespace Splitter.Operations.WebApi;
#pragma warning disable IDE1006 // Naming Styles
public record ReponseDto
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Guid? commandId { get; set; }

    public ReponseDto(Guid commandId) => this.commandId = commandId;
    public ReponseDto(Guid? commandId) => this.commandId = commandId;
    public ReponseDto() => commandId = null;
}

#pragma warning restore IDE1006 // Naming Styles