using System;
using System.Collections.Generic;

namespace Pharm.DAL.entity;

public class Product
{
    public long Id { get; set; }

    public string Pname { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double Price { get; set; }

    public long Quantity { get; set; }

}
