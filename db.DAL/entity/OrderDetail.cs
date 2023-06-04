using System;
using System.Collections.Generic;

namespace Pharm.DAL.entity;

public partial class OrderDetail
{
    public long Id { get; set; }

    public long ProductId { get; set; }

    public long Quantity { get; set; }

    public double TotalPrice { get; set; }

    public double ProductPrice { get; set; }

    public string Address { get; set; }

    public string Number { get; set; }
}
