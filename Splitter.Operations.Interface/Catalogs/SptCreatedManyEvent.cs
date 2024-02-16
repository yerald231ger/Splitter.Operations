namespace Splitter.Operations.Interface;

public class SptCreatedManyEvent<TModel> : SptEvent
{
    public List<TModel> Created { get; set; }

    public SptCreatedManyEvent() => Created = [];

    public SptCreatedManyEvent(List<TModel> model) => Created = model;
}
