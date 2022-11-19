using System;
using System.Collections.Generic;

namespace MonitorBackend.Data.Entity;

public partial class Device : Abstract.Entity
{
    public string Name { get; set; } = null!;

    public virtual ICollection<Load> Loads { get; } = new List<Load>();

    public virtual ICollection<Log> Logs { get; } = new List<Log>();

    public virtual ICollection<Malwarereport> Malwarereports { get; } = new List<Malwarereport>();
}
