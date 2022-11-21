using MonitorBackend.Data.Entity;
using MonitorBackend.Data.Repositories.Abstract;

namespace MonitorBackend.Services;

public class DeviceResourcesService
{
    private readonly IRepository<Load> _loadRepository;
    private readonly IRepository<Data.Entity.Object> _objectRepository;

    public async Task<List<Load>?> GetCpuLoads()
    {
        var objId = _objectRepository.Items.FirstOrDefault(i => i.Name == "CPU")?.Id;
        return objId == null ? null : await GetLoadsByObjectId((int)objId);
    }
    
    public async Task<List<Load>?> GetNetworkLoads()
    {
        var objId = _objectRepository.Items.FirstOrDefault(i => i.Name == "Network")?.Id;
        return objId == null ? null : await GetLoadsByObjectId((int)objId);
    }

    private async Task<List<Load>?> GetLoadsByObjectId(int objectId)
    {
        try
        {
            var _object = await _objectRepository.GetAsync(objectId);
            if (_object == null) return null;
            return _object.Loads.Count == 0 ? null : _object.Loads.ToList();
        }
        catch (Exception e)
        {
            return null;
        }
    }
}