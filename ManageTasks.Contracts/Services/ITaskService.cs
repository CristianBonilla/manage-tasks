using ManageTasks.Domain.Entities;

namespace ManageTasks.Contracts.Services
{
  public interface ITaskService
  {
    Task<TaskEntity> AddTask(TaskEntity task);

    Task<TaskEntity> UpdateTask(Guid taskId, string taskAction, TaskProgressStatus taskProgressStatus);

    Task<TaskEntity> DeleteTask(Guid taskId);

    IAsyncEnumerable<TaskEntity> GetTasks();
  }
}
