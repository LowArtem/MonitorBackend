using Microsoft.AspNetCore.Mvc;
using MonitorBackend.Controllers.Abstract;
using MonitorBackend.Data.Dto;
using MonitorBackend.Data.Dto.Mapper;
using MonitorBackend.Services;

namespace MonitorBackend.Controllers;

public class DeviceResourcesController : BaseApiController
{
    private readonly DeviceResourcesService _deviceResourcesService;

    public DeviceResourcesController(DeviceResourcesService deviceResourcesService)
    {
        _deviceResourcesService = deviceResourcesService;
    }

    [HttpGet]
    [Route("cpu")]
    public async Task<ActionResult<List<LoadDto>>> GetCpuLoads()
    {
        var loads = await _deviceResourcesService.GetCpuLoads();
        if (loads == null) return BadRequest("Error");
        return Ok(loads.Select(l => l.MapToDto()));
    }
    
    [HttpGet]
    [Route("network")]
    public async Task<ActionResult<List<LoadDto>>> GetNetworkLoads()
    {
        var loads = await _deviceResourcesService.GetNetworkLoads();
        if (loads == null) return BadRequest("Error");
        return Ok(loads.Select(l => l.MapToDto()));
    }
}