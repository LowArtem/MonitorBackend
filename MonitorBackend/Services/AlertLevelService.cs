using MonitorBackend.Data.Entity;
using MonitorBackend.Data.Repositories.Abstract;

namespace MonitorBackend.Services;

public class AlertLevelService
{
    private readonly IRepository<Alertlevel> _alertRepository;

    public AlertLevelService(IRepository<Alertlevel> alertRepository)
    {
        _alertRepository = alertRepository;
    }

    public async Task<List<Alertlevel>> GetAllAlertLevels()
    {
        return await _alertRepository.GetAllAsync();
    }
}