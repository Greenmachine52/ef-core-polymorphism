namespace GenericDataPointHandlingDemo.Models.Thresholds
{
  public class TriggeredThreshold
  {
    public TriggeredThreshold(int thresholdId, int triggeringValue)
    {
      ThresholdId = thresholdId;
      TriggeringValue = triggeringValue;
      CreatedAt = DateTime.UtcNow;
    }

    public int Id { get; set; }
    public BaseThreshold Threshold { get; set; }
    public int ThresholdId { get; set; }
    public int TriggeringValue { get; set; }
    public DateTime CreatedAt { get; set; }
  }
}