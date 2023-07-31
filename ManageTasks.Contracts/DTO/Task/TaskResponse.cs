using ManageTasks.Domain.Entities;

namespace ManageTasks.Contracts.DTO.Task
{
  public class TaskResponse
  {
    public Guid TaskId { get; set; }
    public string TaskAction { get; set; } = null!;
    public TaskProgressStatus Status { get; set; }
    public DateTimeOffset Created { get; set; }
  }
}
