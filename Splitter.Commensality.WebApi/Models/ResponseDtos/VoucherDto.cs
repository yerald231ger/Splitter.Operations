﻿using Splitter.Extensions;

namespace Splitter.Commensality.WebApi;

#pragma warning disable IDE1006 // Naming Styles

public record VoucherDto(
    Guid? commandId, 
    Guid id, 
    decimal amount, 
    decimal total, 
    decimal tipAmount, 
    DateTime createdAt, 
    Guid orderId) : ReponseDto(commandId);

#pragma warning restore IDE1006 // Naming Styles