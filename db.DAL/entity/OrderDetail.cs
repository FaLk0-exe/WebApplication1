using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Pharm.DAL.entity;

public partial class OrderDetail
{
    public long Id { get; set; }

    public long ProductId { get; set; }

    public long Quantity { get; set; }

    public double TotalPrice { get; set; }

    public double ProductPrice { get; set; }

    public long UserOrderId { get; set; }
    public string ProductTitle { get; set; }


}
