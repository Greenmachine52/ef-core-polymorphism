namespace GenericDataPointHandlingDemo.Auxiliary;

public class ThresholdTypeMapper
{
  static ThresholdTypeMapper()
  {
    Dictionary = new()
    {
      { ThresholdType.ConcreteSensorTypeOneThresholdOne, typeof(ConcreteSensorOneThreshold) },
      { ThresholdType.ConcreteSensorTypeTwoThresholdOne, typeof(ConcreteSensorTwoThreshold) }
    };
  }

  public static Dictionary<ThresholdType, Type> Dictionary { get; set; }

  public void Test<T>(BaseThreshold threshold) where T : BaseDataPoint
  {
   var dt = ThresholdTypeMapper.Dictionary[ThresholdType.ConcreteSensorTypeOneThresholdOne];
 //  var dta = threshold as dt;
   //      var d =  new ConcreteSensorOneThreshold();
    
  }
}