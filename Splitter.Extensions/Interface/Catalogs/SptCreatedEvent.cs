namespace Splitter.Extensions.Interface.Abstractions;
public class SptCreatedCommensality<TModel> : SptCommensality
{
    public TModel? Created { get; set; }

    public SptCreatedCommensality()
    {
    }

    public SptCreatedCommensality(TModel model) => Created = model;
}
