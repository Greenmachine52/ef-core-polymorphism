namespace GenericDataPointHandlingDemo.Migrations;

public class Context : DbContext
{
  public DbSet<BaseDataPoint> DataPoints { get; set; }
  public DbSet<BaseSensor> Sensors { get; set; }
  public DbSet<BaseThreshold> Thresholds { get; set; }
  public DbSet<TriggeredThreshold> TriggeredThresholds { get; set;}

  public Context(DbContextOptions<Context> options)
    : base(options)
  {
  }


  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);
    // Customize the ASP.NET Identity model and override the defaults if needed.
    // For example, you can rename the ASP.NET Identity table names and more.
    // Add your customizations after calling base.OnModelCreating(builder);

    builder.Entity<BaseSensor>().HasDiscriminator(x => x.SensorType)
      .HasValue<ConcreteSensorTypeOne>(SensorType.ConcreteSensorTypeOne)
      .HasValue<ConcreteSensorTypeTwo>(SensorType.ConcreteSensorTypeTwo);

    builder.Entity<BaseDataPoint>().HasDiscriminator(x => x.DataPointType)
      .HasValue<ConcreteSensorTypeOneDataPoint>(SensorType.ConcreteSensorTypeOne)
      .HasValue<ConcreteSensorTypeTwoDataPoint>(SensorType.ConcreteSensorTypeTwo);

    builder.Entity<BaseThreshold>().HasDiscriminator(x => x.ThresholdType)
      .HasValue<ConcreteSensorOneThreshold>(ThresholdType.ConcreteSensorTypeOneThresholdOne)
      .HasValue<ConcreteSensorTwoThreshold>(ThresholdType.ConcreteSensorTypeTwoThresholdOne);

    #region DataSeeder

    builder.Entity<ConcreteSensorTypeOne>().HasData(new ConcreteSensorTypeOne
    {
      Id = 1,
      Name = "First Sensor",
      SensorType = SensorType.ConcreteSensorTypeOne
    });

    builder.Entity<ConcreteSensorTypeTwo>().HasData(new ConcreteSensorTypeTwo
    {
      Id = 2,
      Name = "Second Sensor",
      SensorType = SensorType.ConcreteSensorTypeOne
    });


    builder.Entity<ConcreteSensorOneThreshold>().HasData(new ConcreteSensorOneThreshold
    {
      Id = 1,
      SensorId = 1,
      HighThresholdValue = 90,
      LowThresholdValue = 50,
      ThresholdType = ThresholdType.ConcreteSensorTypeOneThresholdOne
    });

    builder.Entity<ConcreteSensorOneThreshold>().HasData(new ConcreteSensorTwoThreshold
    {
      Id = 2,
      SensorId = 2,
      HighThresholdValue = 90,
      LowThresholdValue = 50,
      ThresholdType = ThresholdType.ConcreteSensorTypeTwoThresholdOne
    });

    #endregion
  }
}