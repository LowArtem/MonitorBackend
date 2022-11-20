using MonitorBackend.Data.Entity;
using MonitorBackend.Data.Repositories.Abstract;

namespace MonitorBackend.Services;

public class DeviceService
{
    private readonly IRepository<Device> _deviceRepository;

    public DeviceService(IRepository<Device> deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }

    public async Task<List<Device>> GetAllDevices()
    {
        return await _deviceRepository.GetAllAsync();
    }
}