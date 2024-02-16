namespace Splitter.Operations.Interface;
public class SptUpdateManyCompletion<TModel> : SptCompletion
    where TModel : class
{
    public List<TModel> Updated { get; set; }
    public SptUpdateManyCompletion() => Updated = [];

    public SptUpdateManyCompletion(Guid commandId, IEnumerable<TModel> updated)
        : base(commandId) => Updated = new(updated);
}
