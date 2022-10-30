namespace GenericDataPointHandlingDemo.Models.Thresholds.ConcreteSensorOneThresholds;

public class ConcreteSensorOneThreshold : BaseThreshold, IResolvableThreshold<ConcreteSensorTypeOneDataPoint>
{
  public int? TriggeredByDataPoint(ConcreteSensorTypeOneDataPoint dataPoint)
  {
    if (dataPoint.ParameterOne > LowThresholdValue && dataPoint.ParameterOne < HighThresholdValue)
    {
      return null;
    }

    return dataPoint.ParameterOne;
  }
}