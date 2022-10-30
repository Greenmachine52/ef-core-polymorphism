namespace GenericDataPointHandlingDemo.Models.Thresholds;

public abstract class BaseThreshold
{
  public int Id { get; set; }
  public BaseSensor Sensor { get; set; }
  public int SensorId { get; set; }

  public double? LowThresholdValue { get; set; }
  public double? HighThresholdValue { get; set; }
  public ThresholdType ThresholdType { get; set; }
  public ICollection<TriggeredThreshold> TriggeredThresholds { get; set; }
}