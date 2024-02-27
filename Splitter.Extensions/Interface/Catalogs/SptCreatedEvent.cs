namespace Splitter.Extentions.Interface.Abstractions;
public class SptCreatedCommensality<TModel> : SptCommensality
{
    public TModel? Created { get; set; }

    public SptCreatedCommensality()
    {
    }

    public SptCreatedCommensality(TModel model) => Created = model;
}
