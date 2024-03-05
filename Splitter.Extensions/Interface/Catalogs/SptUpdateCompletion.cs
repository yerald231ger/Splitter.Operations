namespace Splitter.Extensions.Interface.Abstractions;
public class SptUpdateCompletion<TModel> : SptCompletion
    where TModel : class
{
    public TModel? Updated { get; set; }
    public SptUpdateCompletion()
    {
    }

    public SptUpdateCompletion(Guid commandId, TModel updated)
        : base(commandId) => Updated = updated;
}
