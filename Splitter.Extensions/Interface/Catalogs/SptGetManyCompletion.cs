namespace Splitter.Extensions.Interface.Abstractions;
public class SptGetManyCompletion<TModel> : SptCompletion
    where TModel : class
{
    public List<TModel> Items { get; set; }

    public SptGetManyCompletion() => Items = [];

    public SptGetManyCompletion(Guid commandId, IEnumerable<TModel> items)
        : base(commandId) => Items = new(items);
}