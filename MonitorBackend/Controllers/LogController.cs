using Microsoft.AspNetCore.Mvc;
using MonitorBackend.Controllers.Abstract;
using MonitorBackend.Data.Dto;
using MonitorBackend.Data.Dto.Mapper;
using MonitorBackend.Data.Entity;
using MonitorBackend.Services;

namespace MonitorBackend.Controllers;

public class LogController : BaseApiController
{
    private readonly LogService _logService;

    public LogController(LogService logService)
    {
        _logService = logService;
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<LogDto>>> GetAllLogs()
    {
        var logs = await _logService.GetAllLogs();
        return logs == null ? BadRequest("") : Ok(logs.Select(l => l.MapToDto()));
    }
    
    [HttpGet]
    [Route("computer/{computerId:int}")]
    public async Task<ActionResult<List<LogDto>>> GetLogsByComputer([FromRoute] int computerId)
    {
        var logs = await _logService.GetLogsByComputerId(computerId);
        return logs == null ? BadRequest("") : Ok(logs.Select(l => l.MapToDto()));
    }
    
    [HttpGet]
    [Route("type/{typeId:int}")]
    public async Task<ActionResult<List<LogDto>>> GetLogsByType([FromRoute] int typeid)
    {
        var logs = await _logService.GetLogsByType(typeid);
        return logs == null ? BadRequest("") : Ok(logs.Select(l => l.MapToDto()));
    }
    
    [HttpGet]
    [Route("alert/{alertId:int}")]
    public async Task<ActionResult<List<LogDto>>> GetLogsByAlert([FromRoute] int alertId)
    {
        var logs = await _logService.GetLogsByAlertLevel(alertId);
        return logs == null ? BadRequest("") : Ok(logs.Select(l => l.MapToDto()));
    }

    [HttpPost]
    [Route("")]
    public async Task AddLogs([FromBody] List<Log> logs)
    {
        await _logService.AddLogs(logs);
    }
}