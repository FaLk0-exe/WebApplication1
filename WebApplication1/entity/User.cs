using System;
using System.Collections.Generic;

namespace WebApplication1.entity;

public partial class User
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long Password { get; set; }

    public DateTime BirthDate { get; set; }

}
