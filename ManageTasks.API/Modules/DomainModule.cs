using Autofac;
using ManageTasks.Contracts.Repository;
using ManageTasks.Domain.Context;
using ManageTasks.Domain.Repositories;
using ManageTasks.Infrastructure.Repository;

namespace ManageTasks.API.Modules
{
  class DomainModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterGeneric(typeof(RepositoryContext<>))
        .As(typeof(IRepositoryContext<>))
        .InstancePerLifetimeScope();
      builder.RegisterGeneric(typeof(Repository<,>))
        .As(typeof(IRepository<,>))
        .InstancePerLifetimeScope();

      builder.RegisterType<ManageTasksRepositoryContext>()
        .As<IManageTasksRepositoryContext>()
        .InstancePerLifetimeScope();

      builder.RegisterType<TaskRepository>()
        .As<ITaskRepository>()
        .InstancePerLifetimeScope();
    }
  }
}
