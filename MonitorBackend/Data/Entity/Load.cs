using System;
using System.Collections.Generic;

namespace MonitorBackend.Data.Entity;

public partial class Load
{
    public int Id { get; set; }

    public int Value { get; set; }

    public DateTime Datetime { get; set; }

    public int IdObject { get; set; }

    public int IdDevice { get; set; }

    public virtual Device IdDeviceNavigation { get; set; } = null!;

    public virtual Object IdObjectNavigation { get; set; } = null!;
}
