﻿using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace MonitorBackend.Controllers.Abstract;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public abstract class BaseApiController : ControllerBase
{
    
}