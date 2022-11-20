using MonitorBackend.Data.Entity;

namespace MonitorBackend.Services;

public static class ServiceRegister
{
    public static IServiceCollection AddServices(this IServiceCollection services) => services
        .AddScoped<LogService>()
        .AddScoped<AlertLevelService>()
        .AddScoped<DeviceService>()
        .AddScoped<MalwareService>()
        .AddScoped<MalwaresTypeService>()
        .AddScoped<TypesOfLogService>();
}