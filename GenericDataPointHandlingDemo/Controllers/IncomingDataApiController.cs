using Microsoft.AspNetCore.Mvc;

namespace GenericDataPointHandlingDemo.Controllers;

[ApiController]
[Route("api/incoming-data")]
public class IncomingDataApiController : ControllerBase
{
  private readonly IMapper _mapper;
  private readonly IIncomingDataResolutionService _incomingDataResolutionService;

  public IncomingDataApiController(IIncomingDataResolutionService incomingDataResolutionService, IMapper mapper)
  {
    _incomingDataResolutionService = incomingDataResolutionService;
    _mapper = mapper;
  }

  [HttpPost("type-one-sensor")]
  public async Task<IActionResult> ConcreteSensorTypeOneDataResolution(ConcreteSensorOneDatapointDto dto)
  {
    var dataPoint = _mapper.Map<ConcreteSensorTypeOneDataPoint>(dto);
    await _incomingDataResolutionService.ResolveDataPoint(dataPoint);
    return Ok();
  }

  [HttpPost("type-two-sensor")]
  public async Task<IActionResult> ConcreteSensorTypeTwoDataResolution(ConcreteSensorTwoDatapointDto dto)
  {
    var dataPoint = _mapper.Map<ConcreteSensorTypeTwoDataPoint>(dto);
    await _incomingDataResolutionService.ResolveDataPoint(dataPoint);
    return Ok();
  }
}