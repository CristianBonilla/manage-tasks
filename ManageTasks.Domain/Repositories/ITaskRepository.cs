using ManageTasks.Contracts.Repository;
using ManageTasks.Domain.Context;
using ManageTasks.Domain.Entities;

namespace ManageTasks.Domain.Repositories
{
  public interface ITaskRepository : IRepository<ManageTasksContext, TaskEntity> { }
}
