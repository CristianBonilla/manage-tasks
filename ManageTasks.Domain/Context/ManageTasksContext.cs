using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace ManageTasks.Domain.Context
{
  public class ManageTasksContext : DbContext
  {
    public ManageTasksContext(DbContextOptions<ManageTasksContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
  }
}
