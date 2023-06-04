using System;
using System.Collections.Generic;

namespace WebApplication1.entity;

public partial class Product
{
    public long Id { get; set; }

    public string Pname { get; set; } = null!;

    public double Price { get; set; }

    public long Quantity { get; set; }

}
