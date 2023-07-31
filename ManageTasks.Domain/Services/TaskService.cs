using System.Net;
using ManageTasks.Contracts.Exceptions;
using ManageTasks.Contracts.Services;
using ManageTasks.Domain.Context;
using ManageTasks.Domain.Entities;
using ManageTasks.Domain.Repositories;

namespace ManageTasks.Domain.Services
{
  public class TaskService : ITaskService
  {
    readonly IManageTasksRepositoryContext _context;
    readonly ITaskRepository _taskRepository;

    public TaskService(
      IManageTasksRepositoryContext context,
      ITaskRepository taskRepository)
    {
      _context = context;
      _taskRepository = taskRepository;
    }

    public async Task<TaskEntity> AddTask(TaskEntity task)
    {
      TaskEntity addedTask = _taskRepository.Create(task);
      await _context.SaveAsync();

      return addedTask;
    }

    public async Task<TaskEntity> UpdateTaskByAction(Guid taskId, string taskAction)
    {
      TaskEntity task = GetTask(taskId);
      task.TaskAction = taskAction;
      await _context.SaveAsync();

      return task;
    }

    public async Task<TaskEntity> UpdateTaskByStatus(Guid taskId, TaskProgressStatus taskProgressStatus)
    {
      TaskEntity task = GetTask(taskId);
      task.Status = taskProgressStatus;
      await _context.SaveAsync();

      return task;
    }

    public async Task<TaskEntity> DeleteTask(Guid taskId)
    {
      TaskEntity task = GetTask(taskId);
      TaskEntity deletedTask = _taskRepository.Delete(task);
      await _context.SaveAsync();

      return deletedTask;
    }

    public IAsyncEnumerable<TaskEntity> GetTasks() => _taskRepository.Get().ToAsyncEnumerable();

    private TaskEntity GetTask(Guid taskId)
    {
      TaskEntity task = _taskRepository.Find(taskId)
        ?? throw new ServiceErrorException(HttpStatusCode.NotFound, $"Task not found with task id \"{taskId}\"");

      return task;
    }
  }
}
