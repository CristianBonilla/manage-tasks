using ManageTasks.Infrastructure.Repository;

namespace ManageTasks.Domain.Context
{
  public class ManageTasksRepositoryContext : RepositoryContext<ManageTasksContext>, IManageTasksRepositoryContext
  {
    public ManageTasksRepositoryContext(ManageTasksContext context) : base(context) { }
  }
}
