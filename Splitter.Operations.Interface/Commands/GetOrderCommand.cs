﻿namespace Splitter.Operations.Interface;

public class GetOrderCommand(Guid? orderId, DateTime? from, DateTime? to, bool withProducts, bool withVouchers) : SptCommand
{
    public Guid? OrderId { get; set; } = orderId;
    public DateTime? From { get; set; } = from;
    public DateTime? To { get; set; } = to;
    public bool WithProducts { get; set; } = withProducts;
    public bool WithVouchers { get; set; } = withVouchers;
}
