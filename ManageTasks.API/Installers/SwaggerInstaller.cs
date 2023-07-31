using ManageTasks.API.Filters;
using ManageTasks.API.Options;

namespace ManageTasks.API.Installers
{
  class SwaggerInstaller : IInstaller
  {
    public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
    {
      IConfigurationSection swaggerSection = configuration.GetSection(nameof(SwaggerOptions));
      services.Configure<SwaggerOptions>(swaggerSection);
      SwaggerOptions swagger = swaggerSection.Get<SwaggerOptions>();
      services.AddSwaggerGen(options =>
      {
        options.SwaggerDoc("v1", new()
        {
          Title = "Manage Tasks API",
          Version = "v1",
          Description = "Backend project with an API to manage tasks",
          Contact = swagger.Contact
        });
        options.SchemaFilter<EnumSchemaFilter>();
      });
    }
  }
}
