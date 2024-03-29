﻿namespace Splitter.Operations.Interface;
public static class ISptInterfaceBaseExtensions
{
    public static SptRejection<TCode> Reject<TCode>(this ISptInterface _, Guid commandId, TCode rejectionCode, string? message = null) where TCode : notnull, Enum
        => new(commandId, rejectionCode, message);
}
