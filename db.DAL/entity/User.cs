using System;
using System.Collections.Generic;

namespace Pharm.DAL.entity;

public partial class User
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Password { get; set; }

    public DateTime BirthDate { get; set; }

    public string Address { get; set; }

    public string Number { get; set; }

}
