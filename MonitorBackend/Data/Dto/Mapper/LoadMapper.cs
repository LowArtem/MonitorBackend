using MonitorBackend.Data.Entity;

namespace MonitorBackend.Data.Dto.Mapper;

public static class LoadMapper
{
    public static LoadDto MapToDto(this Load load) =>
        new LoadDto(load.Value, load.Datetime, load.IdObject, load.IdDevice);
}