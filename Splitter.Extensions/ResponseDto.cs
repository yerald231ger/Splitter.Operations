
using System.Text.Json.Serialization;

namespace Splitter.Extensions;

public record ReponseDto
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Guid? CommandId { get; set; }

    public ReponseDto(Guid commandId) => CommandId = commandId;
    public ReponseDto(Guid? commandId) => CommandId = commandId;
    public ReponseDto() => CommandId = null;
}