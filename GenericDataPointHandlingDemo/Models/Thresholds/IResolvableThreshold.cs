namespace GenericDataPointHandlingDemo.Models.Thresholds;

public interface IResolvableThreshold<in T> where T : BaseDataPoint
{
  int Id { get; set; }
  int? TriggeredByDataPoint(T dataPoint);
}