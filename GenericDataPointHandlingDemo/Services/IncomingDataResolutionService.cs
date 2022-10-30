namespace GenericDataPointHandlingDemo.Services
{
  public class IncomingDataResolutionService : IIncomingDataResolutionService
  {
    private readonly Context _context;

    public IncomingDataResolutionService(Context context)
    {
      _context = context;
    }


    public async Task ResolveDataPoint<T>(T dataPoint) where T : BaseDataPoint
    {
      var thresholds = (await _context.Thresholds
          .Where(x => x.SensorId == dataPoint.SensorId).ToListAsync())
        .Select(x => (IResolvableThreshold<T>)x);


      _context.Add(dataPoint);

      foreach (var threshold in thresholds)
      {
        var triggeringValue = threshold.TriggeredByDataPoint(dataPoint);
        if (triggeringValue.HasValue)
        {
          _context.TriggeredThresholds.Add(new TriggeredThreshold(threshold.Id, triggeringValue.Value));
        }
      }

      await _context.SaveChangesAsync();
    }
  }
}