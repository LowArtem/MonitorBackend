using MonitorBackend.Data.Entity;

namespace MonitorBackend.Data.Dto.Mapper;

public static class LogMapper
{
    public static LogDto MapToDto(this Log log) => new LogDto(
        log.Source, log.Timegenerated, log.Eventid, log.Instanceid, log.Username, log.Data, log.IdDeviceNavigation.Name,
        log.IdDevice, log.IdAlertlevel, log.IdTypeoflog
    );
}