using ManageTasks.Domain.Context;
using ManageTasks.Domain.Entities;
using ManageTasks.Infrastructure.Repository;

namespace ManageTasks.Domain.Repositories
{
  public class TaskRepository : Repository<ManageTasksContext, TaskEntity>, ITaskRepository
  {
    public TaskRepository(IManageTasksRepositoryContext context) : base(context) { }
  }
}
