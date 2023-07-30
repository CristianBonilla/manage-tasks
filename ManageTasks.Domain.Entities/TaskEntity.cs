using TaskStatus = ManageTasks.Contracts.DTO.TaskStatus;

namespace ManageTasks.Domain.Entities
{
  public class TaskEntity
  {
    public Guid TaskId { get; set; }
    public string TaskDescription { get; set; } = null!;
    public TaskStatus Status { get; set; }
    public DateTimeOffset Created { get; set; }
  }
}
