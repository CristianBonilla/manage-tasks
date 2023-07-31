using ManageTasks.Domain.Entities;

namespace ManageTasks.Contracts.Services
{
  public interface ITaskService
  {
    Task<TaskEntity> AddTask(TaskEntity task);

    Task<TaskEntity> UpdateTaskByAction(Guid taskId, string taskAction);

    Task<TaskEntity> UpdateTaskByStatus(Guid taskId, TaskProgressStatus taskProgressStatus);

    Task<TaskEntity> DeleteTask(Guid taskId);

    IAsyncEnumerable<TaskEntity> GetTasks();
  }
}
