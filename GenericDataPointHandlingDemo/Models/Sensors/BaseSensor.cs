namespace GenericDataPointHandlingDemo.Models.Sensors;

public abstract class BaseSensor
{
  public int Id { get; set; }
  public string Name { get; set; }
  public ICollection<BaseThreshold> Thresholds { get; set; }
  public ICollection<BaseDataPoint> DataPoints { get; set; }

  public SensorType SensorType { get; set; }
}