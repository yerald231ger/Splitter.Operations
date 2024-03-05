namespace Splitter.Extensions.Interface.Abstractions;
public class SptUpsertCompletion<TModel> : SptCompletion
{
    public TModel? Upserted { get; set; }

    public SptUpsertCompletion()
    {
    }

    public SptUpsertCompletion(Guid commandId, TModel upserted)
        : base(commandId) => Upserted = upserted;
}