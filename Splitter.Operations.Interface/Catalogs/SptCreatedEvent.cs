namespace Splitter.Operations.Interface;
public class SptCreatedEvent<TModel> : SptEvent
{
    public TModel? Created { get; set; }

    public SptCreatedEvent()
    {
    }

    public SptCreatedEvent(TModel model) => Created = model;
}
