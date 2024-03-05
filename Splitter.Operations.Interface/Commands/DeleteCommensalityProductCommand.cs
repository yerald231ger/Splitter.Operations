﻿using Splitter.Extensions.Interface.Abstractions;

namespace Splitter.Operations.Interface;

public class DeleteCommensalityProductCommand(Guid? commandId, Guid CommensalityId, Guid productId) : SptCommand(commandId)
{
    public Guid CommensalityId { get; set; } = CommensalityId;
    public Guid ProductId { get; set; } = productId;
}
