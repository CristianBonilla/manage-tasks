using ManageTasks.Domain.Entities;

namespace ManageTasks.Contracts.DTO.Task
{
  public class TaskRequest
  {
    public string Action { get; set; } = null!;
    public TaskProgressStatus Status { get; set; }
  }
}
