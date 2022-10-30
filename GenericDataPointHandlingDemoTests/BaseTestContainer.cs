using AutoMapper;
using GenericDataPointHandlingDemo.Controllers;
using GenericDataPointHandlingDemo.MappingProfiles;

namespace GenericDataPointHandlingDemoTests;

public class BaseTestContainer
{
  protected ServiceProvider ServiceProvider = null!;
  protected Context Context = null!;
  protected IncomingDataApiController IncomingDataApiController = null!;

  [SetUp]
  public void Setup()
  {
    var services = new ServiceCollection();
    services.AddDbContext<Context>(options =>
      options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

    services.AddScoped<IIncomingDataResolutionService, IncomingDataResolutionService>();

    var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

    IMapper mapper = mapperConfig.CreateMapper();
    services.AddSingleton(mapper);

    ServiceProvider = services.BuildServiceProvider();
    Context = ServiceProvider.GetRequiredService<Context>();
    IncomingDataApiController = new IncomingDataApiController(
      ServiceProvider.GetRequiredService<IIncomingDataResolutionService>(), mapper);
  }
}