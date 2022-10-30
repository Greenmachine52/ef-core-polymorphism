namespace GenericDataPointHandlingDemo.Models.DataPoints;

public abstract class BaseDataPoint
{
  public int Id { get; set; }
  public BaseSensor Sensor { get; set; }
  public int SensorId { get; set; }
  public SensorType DataPointType { get; set; }
}