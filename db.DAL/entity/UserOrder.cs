﻿using System;
using System.Collections.Generic;

namespace Pharm.DAL.entity;

public partial class UserOrder
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public double Price { get; set; }

    public string OrderDate { get; set; } 

    public long StatusId { get; set; }

    public string Address { get; set; }

    public string Number { get; set; }

}
