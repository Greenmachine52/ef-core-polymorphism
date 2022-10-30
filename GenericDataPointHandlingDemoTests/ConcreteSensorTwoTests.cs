using System.Collections.Generic;
using System.Linq;
using GenericDataPointHandlingDemo.Dtos;
using GenericDataPointHandlingDemo.Enums;
using GenericDataPointHandlingDemo.Models.Sensors;
using GenericDataPointHandlingDemo.Models.Thresholds;
using GenericDataPointHandlingDemo.Models.Thresholds.ConcreteSensorOneThresholds;
using GenericDataPointHandlingDemo.Models.Thresholds.ConcreteSensorTwoThresholds;

namespace GenericDataPointHandlingDemoTests;

public class ConcreteSensorTwoTests : BaseTestContainer
{
  [Test]
  public async Task ThresholdTriggersIfLower()
  {
    var sensor = CreateSensor();

    Context.Sensors.Add(sensor);
    await Context.SaveChangesAsync();

    var dataPointDto = new ConcreteSensorTwoDatapointDto
    {
      ParameterOne = 1,
      SensorId = 1
    };

    await IncomingDataApiController.ConcreteSensorTypeTwoDataResolution(dataPointDto);

    await Context.TriggeredThresholds
      .SingleAsync(x =>
        x.ThresholdId == sensor.Thresholds.First().Id && x.TriggeringValue == dataPointDto.ParameterOne);
  }

  [Test]
  public async Task ThresholdTriggersIfHigher()
  {
    var sensor = CreateSensor();

    Context.Sensors.Add(sensor);
    await Context.SaveChangesAsync();

    var dataPointDto = new ConcreteSensorTwoDatapointDto
    {
      ParameterOne = 99,
      SensorId = 1
    };

    await IncomingDataApiController.ConcreteSensorTypeTwoDataResolution(dataPointDto);

    await Context.TriggeredThresholds
      .SingleAsync(x =>
        x.ThresholdId == sensor.Thresholds.First().Id && x.TriggeringValue == dataPointDto.ParameterOne);
  }

  [Test]
  public async Task ThresholdDoesNotTriggerWhenCriteriaAreMet()
  {
    var sensor = CreateSensor();

    Context.Sensors.Add(sensor);
    await Context.SaveChangesAsync();

    var dataPointDto = new ConcreteSensorTwoDatapointDto
    {
      ParameterOne = 55,
      SensorId = 1
    };

    await IncomingDataApiController.ConcreteSensorTypeTwoDataResolution(dataPointDto);

    var exists = await Context.TriggeredThresholds.AnyAsync();
    Assert.False(exists);
  }


  private BaseSensor CreateSensor()
  {
    var sensor = new ConcreteSensorTypeTwo
    {
      Id = 1,
      SensorType = SensorType.ConcreteSensorTypeTwo,
      Name = "Test",
      Thresholds = new List<BaseThreshold>
      {
        new ConcreteSensorTwoThreshold
        {
          SensorId = 1,
          ThresholdType = ThresholdType.ConcreteSensorTypeTwoThresholdOne,
          HighThresholdValue = 90,
          LowThresholdValue = 50
        }
      }
    };
    return sensor;
  }
}