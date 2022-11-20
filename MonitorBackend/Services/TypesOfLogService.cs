using MonitorBackend.Data.Entity;
using MonitorBackend.Data.Repositories.Abstract;

namespace MonitorBackend.Services;

public class TypesOfLogService
{
    private readonly IRepository<Typesoflog> _typesRepository;

    public TypesOfLogService(IRepository<Typesoflog> typesRepository)
    {
        _typesRepository = typesRepository;
    }

    public async Task<List<Typesoflog>> GetAllLogTypes()
    {
        return await _typesRepository.GetAllAsync();
    }
}