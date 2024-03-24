﻿namespace Splitter.Commensality.Models;

public class Tag
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public virtual List<OrderProduct>? Products { get; set; }
}