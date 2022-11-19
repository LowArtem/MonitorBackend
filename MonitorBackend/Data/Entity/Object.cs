﻿using System;
using System.Collections.Generic;

namespace MonitorBackend.Data.Entity;

public partial class Object
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Load> Loads { get; } = new List<Load>();
}
