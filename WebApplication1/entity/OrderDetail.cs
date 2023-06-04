using System;
using System.Collections.Generic;

namespace WebApplication1.entity;

public partial class OrderDetail
{
    public long Id { get; set; }

    public long ProductId { get; set; }

    public long Quantity { get; set; }

    public double TotalPrice { get; set; }

    public double ProductPrice { get; set; }
}
