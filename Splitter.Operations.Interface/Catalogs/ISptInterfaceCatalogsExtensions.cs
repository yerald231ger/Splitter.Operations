namespace Splitter.Operations.Interface;
public static class ISptInterfaceCatalogsExtensions
{
    public static SptCreateCompletion<TModel> CompleteCreate<TModel>(this ISptInterface _, Guid commandId, TModel model) where TModel : class
       => new(commandId, model);

    public static SptCreateManyCompletion<TModel> CompleteCreate<TModel>(this ISptInterface _, Guid commandId, IEnumerable<TModel> model) where TModel : class
        => new(commandId, model);

    public static SptUpdateCompletion<TModel> CompleteUpdate<TModel>(this ISptInterface _, Guid commandId, TModel model) where TModel : class
        => new(commandId, model);
    public static SptUpdateManyCompletion<TModel> CompleteUpdate<TModel>(this ISptInterface _, Guid commandId, IEnumerable<TModel> model) where TModel : class
        => new(commandId, model);

    public static SptUpsertCompletion<TModel> CompleteUpsert<TModel>(this ISptInterface _, Guid commandId, TModel model) where TModel : class
        => new(commandId, model);

    public static SptGetCompletion<TModel> CompleteGet<TModel>(this ISptInterface _, Guid commandId, TModel model) where TModel : class, new()
        => new(commandId, model);

    public static SptGetManyCompletion<TModel> CompleteGet<TModel>(this ISptInterface _, Guid commandId, IEnumerable<TModel> model) where TModel : class, new()
        => new(commandId, model);

    public static SptCreatedEvent<TModel> CreatedEvent<TModel>(this ISptInterface _, TModel model) where TModel : class
        => new(model);

    public static SptUpdatedEvent<TModel> UpdatedEvent<TModel>(this ISptInterface _, TModel old, TModel @new) where TModel : class
        => new(old, @new);
}
