using System;
using System.Collections.Generic;

namespace MonitorBackend.Data.Entity;

public partial class Log : Abstract.Entity
{
    public string Source { get; set; } = null!;

    public DateTime Timegenerated { get; set; }

    public int Eventid { get; set; }

    public long Instanceid { get; set; }

    public string Username { get; set; } = null!;

    public string Data { get; set; } = null!;

    public int IdDevice { get; set; }

    public int IdAlertlevel { get; set; }

    public int IdTypeoflog { get; set; }

    public virtual Alertlevel IdAlertlevelNavigation { get; set; } = null!;

    public virtual Device IdDeviceNavigation { get; set; } = null!;

    public virtual Typesoflog IdTypeoflogNavigation { get; set; } = null!;

    public Log()
    {
        
    }
    
    public Log(string source, DateTime timegenerated, int eventid, long instanceid, string username, string data, int idDevice, int idAlertlevel, int idTypeoflog)
    {
        Source = source;
        Timegenerated = timegenerated;
        Eventid = eventid;
        Instanceid = instanceid;
        Username = username;
        Data = data;
        IdDevice = idDevice;
        IdAlertlevel = idAlertlevel;
        IdTypeoflog = idTypeoflog;
    }
}
