using System;
using System.Collections.Generic;

namespace WebApplication1.entity;

public partial class UserOrder
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public double Price { get; set; }

    public DateTime OrderDate { get; set; } 

    public long StatusId { get; set; }

}
