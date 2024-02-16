namespace Splitter.Operations.Interface;
public class SptCreateCompletion<TModel> : SptCompletion
    where TModel : class
{
    public TModel? Created { get; set; }
    public SptCreateCompletion()
    {
    }

    public SptCreateCompletion(Guid commandId, TModel created)
        : base(commandId) => Created = created;
}