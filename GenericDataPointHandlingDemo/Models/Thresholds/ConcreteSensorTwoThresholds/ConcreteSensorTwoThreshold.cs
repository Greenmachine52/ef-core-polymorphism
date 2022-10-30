namespace GenericDataPointHandlingDemo.Models.Thresholds.ConcreteSensorTwoThresholds;

public class ConcreteSensorTwoThreshold : BaseThreshold, IResolvableThreshold<ConcreteSensorTypeTwoDataPoint>
{
  public int? TriggeredByDataPoint(ConcreteSensorTypeTwoDataPoint dataPoint)
  {
    if (dataPoint.ParameterOne > LowThresholdValue && dataPoint.ParameterOne < HighThresholdValue)
    {
      return null;
    }

    return dataPoint.ParameterOne;
  }
}