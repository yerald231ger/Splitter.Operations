namespace Splitter.Extensions.Interface.Abstractions;
public class SptUpdatedCommensality<TModel> : SptCommensality
{
    public TModel? Old { get; set; }
    public TModel? New { get; set; }

    public SptUpdatedCommensality()
    {
    }

    public SptUpdatedCommensality(TModel old, TModel @new)
    {
        Old = old;
        New = @new;
    }
}
