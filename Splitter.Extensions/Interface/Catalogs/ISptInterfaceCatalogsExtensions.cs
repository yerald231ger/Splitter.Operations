namespace Splitter.Extensions.Interface.Abstractions;
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

    public static SptGetCompletion<TModel> CompleteGet<TModel>(this ISptInterface _, Guid commandId, TModel model) where TModel : class
        => new(commandId, model);

    public static SptGetManyCompletion<TModel> CompleteGet<TModel>(this ISptInterface _, Guid commandId, IEnumerable<TModel> model) where TModel : class
        => new(commandId, model);
}
