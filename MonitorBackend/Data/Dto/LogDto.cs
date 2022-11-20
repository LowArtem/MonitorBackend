namespace MonitorBackend.Data.Dto;

public record LogDto(string Source, DateTime TimeGenerated, int EventId, long InstanceId, string Username, 
    string Data, string DeviceName, int DeviceId, int AlertLevelId, int TypeOfLogId);