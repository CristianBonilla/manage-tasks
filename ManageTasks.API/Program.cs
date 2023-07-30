using Microsoft.EntityFrameworkCore;
using Autofac.Extensions.DependencyInjection;
using ManageTasks.Domain.Context;

namespace ManageTasks.API
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      IHost host = CreateHostBuilder(args).Build();
      await DbMigrationStart<ManageTasksContext>(host);
      await host.RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
          .UseServiceProviderFactory(new AutofacServiceProviderFactory())
          .ConfigureWebHostDefaults(webBuilder =>
          {
            webBuilder.UseStartup<Startup>();
          });

    private static async Task DbMigrationStart<TContext>(IHost host) where TContext : DbContext
    {
      using IServiceScope serviceScope = host.Services.CreateScope();
      TContext dbContext = serviceScope.ServiceProvider.GetRequiredService<TContext>();
      await dbContext.Database.MigrateAsync();
    }
  }
}
