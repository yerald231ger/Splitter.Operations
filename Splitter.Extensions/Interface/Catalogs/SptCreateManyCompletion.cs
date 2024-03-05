namespace Splitter.Extensions.Interface.Abstractions;
public class SptCreateManyCompletion<TModel> : SptCompletion
    where TModel : class
{
    public List<TModel>? Created { get; set; }
    public SptCreateManyCompletion() => Created = [];

    public SptCreateManyCompletion(Guid commandId, IEnumerable<TModel> created)
        : base(commandId) => Created = new(created);
}