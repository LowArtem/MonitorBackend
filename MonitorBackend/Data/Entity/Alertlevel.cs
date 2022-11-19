using System;
using System.Collections.Generic;

namespace MonitorBackend.Data.Entity;

public partial class Alertlevel : Abstract.Entity
{
    public string Name { get; set; } = null!;

    public virtual ICollection<Log> Logs { get; } = new List<Log>();
}
