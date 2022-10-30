using System.Collections.Generic;
using System.Linq;
using GenericDataPointHandlingDemo.Dtos;
using GenericDataPointHandlingDemo.Enums;
using GenericDataPointHandlingDemo.Models.Sensors;
using GenericDataPointHandlingDemo.Models.Thresholds;
using GenericDataPointHandlingDemo.Models.Thresholds.ConcreteSensorOneThresholds;

namespace GenericDataPointHandlingDemoTests;

public class ConcreteSensorOneTests : BaseTestContainer
{
  [Test]
  public async Task ThresholdTriggersIfLower()
  {
    var sensor = CreateSensor();

    Context.Sensors.Add(sensor);
    await Context.SaveChangesAsync();

    var dataPointDto = new ConcreteSensorOneDatapointDto
    {
      ParameterOne = 1,
      SensorId = 1
    };

    await IncomingDataApiController.ConcreteSensorTypeOneDataResolution(dataPointDto);

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

    var dataPointDto = new ConcreteSensorOneDatapointDto
    {
      ParameterOne = 99,
      SensorId = 1
    };

    await IncomingDataApiController.ConcreteSensorTypeOneDataResolution(dataPointDto);

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

    var dataPointDto = new ConcreteSensorOneDatapointDto
    {
      ParameterOne = 55,
      SensorId = 1
    };

    await IncomingDataApiController.ConcreteSensorTypeOneDataResolution(dataPointDto);

    var exists = await Context.TriggeredThresholds.AnyAsync();
    Assert.False(exists);
  }


  private BaseSensor CreateSensor()
  {
    var sensor = new ConcreteSensorTypeOne
    {
      Id = 1,
      SensorType = SensorType.ConcreteSensorTypeOne,
      Name = "Test",
      Thresholds = new List<BaseThreshold>
      {
        new ConcreteSensorOneThreshold
        {
          SensorId = 1,
          ThresholdType = ThresholdType.ConcreteSensorTypeOneThresholdOne,
          HighThresholdValue = 90,
          LowThresholdValue = 50
        }
      }
    };
    return sensor;
  }
}