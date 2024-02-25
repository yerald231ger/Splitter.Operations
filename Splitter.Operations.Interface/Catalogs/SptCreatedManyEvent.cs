namespace Splitter.Operations.Interface;

public class SptCreatedManyCommensality<TModel> : SptCommensality
{
    public List<TModel> Created { get; set; }

    public SptCreatedManyCommensality() => Created = [];

    public SptCreatedManyCommensality(List<TModel> model) => Created = model;
}
