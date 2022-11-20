using Microsoft.EntityFrameworkCore;
using MonitorBackend.Data.Entity;
using MonitorBackend.Data.Repositories.Abstract;

namespace MonitorBackend.Services;

public class LogService
{
    private readonly IRepository<Log> _logRepository;

    public LogService(IRepository<Log> logRepository)
    {
        _logRepository = logRepository;
    }

    public async Task<List<Log>?> GetAllLogs()
    {
        try
        {
            var logs = await _logRepository.GetAllAsync();
            return logs.Count == 0 ? null : logs;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<List<Log>?> GetLogsByComputerId(int computerId)
    {
        try
        {
            var logs = await _logRepository.Items.Where(item => item.IdDevice == computerId).ToListAsync();
            return logs.Count == 0 ? null : logs;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<List<Log>?> GetLogsByType(int typeId)
    {
        try
        {
            var logs = await _logRepository.Items.Where(item => item.IdTypeoflog == typeId).ToListAsync();
            return logs.Count == 0 ? null : logs;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<List<Log>?> GetLogsByAlertLevel(int alertLevelId)
    {
        try
        {
            var logs = await _logRepository.Items.Where(item => item.IdAlertlevel == alertLevelId).ToListAsync();
            return logs.Count == 0 ? null : logs;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task AddLogs(List<Log> logs)
    {
        _logRepository.AutoSaveChanges = false;
        foreach (var log in logs)
        {
            await _logRepository.AddAsync(log);
        }

        await _logRepository.SaveChangesAsync();
        _logRepository.AutoSaveChanges = true;
    }
}