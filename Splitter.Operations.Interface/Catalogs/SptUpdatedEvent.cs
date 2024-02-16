namespace Splitter.Operations.Interface;
public class SptUpdatedEvent<TModel> : SptEvent
{
    public TModel? Old { get; set; }
    public TModel? New { get; set; }

    public SptUpdatedEvent()
    {
    }

    public SptUpdatedEvent(TModel old, TModel @new)
    {
        Old = old;
        New = @new;
    }
}
