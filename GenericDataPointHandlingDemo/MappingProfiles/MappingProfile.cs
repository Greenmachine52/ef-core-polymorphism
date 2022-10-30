namespace GenericDataPointHandlingDemo.MappingProfiles;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<ConcreteSensorOneDatapointDto, ConcreteSensorTypeOneDataPoint>();
    CreateMap<ConcreteSensorTwoDatapointDto, ConcreteSensorTypeTwoDataPoint>();
  }
}