namespace GenericDataPointHandlingDemo.Services.Interfaces;

public interface IIncomingDataResolutionService
{
  Task ResolveDataPoint<T>(T dataPoint) where T : BaseDataPoint;
}