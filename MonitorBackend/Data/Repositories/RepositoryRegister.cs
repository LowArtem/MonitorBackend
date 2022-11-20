using MonitorBackend.Data.Entity;
using MonitorBackend.Data.Repositories.Abstract;
using Object = MonitorBackend.Data.Entity.Object;

namespace MonitorBackend.Data.Repositories;

public static class RepositoryRegister
{
    public static IServiceCollection AddRepositories(this IServiceCollection services) => services
        .AddScoped<IRepository<Alertlevel>, DbRepository<Alertlevel>>()
        .AddScoped<IRepository<Device>, DbRepository<Device>>()
        .AddScoped<IRepository<Load>, LoadRepository>()
        .AddScoped<IRepository<Log>, LogRepository>()
        .AddScoped<IRepository<Malwarereport>, MalwareReportRepository>()
        .AddScoped<IRepository<Malwaretype>, DbRepository<Malwaretype>>()
        .AddScoped<IRepository<Object>, DbRepository<Object>>()
        .AddScoped<IRepository<Typesoflog>, DbRepository<Typesoflog>>();
}