﻿namespace Splitter.Extensions.Interface.Abstractions;
public class SptGetCompletion<TModel> : SptCompletion
    where TModel : class
{
    public TModel? Item { get; set; }

    public SptGetCompletion()
    {
    }

    public SptGetCompletion(Guid commandId, TModel item)
        : base(commandId) => Item = item;
}
