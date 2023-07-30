using AutoMapper;
using ManageTasks.API.Mappings.Profiles;

namespace ManageTasks.API.Mappings
{
  class MapperStart
  {
    public static MapperConfiguration Build()
    {
      MapperConfiguration configuration = new(configuration => configuration.AddProfile<ManageTasksProfile>());
      configuration.AssertConfigurationIsValid();

      return configuration;
    }
  }
}
