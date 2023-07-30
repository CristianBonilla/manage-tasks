namespace ManageTasks.Contracts.DTO.Task
{
  public class TaskRequest
  {
    public string TaskAction { get; set; } = null!;
    public TaskProgressStatus Status { get; set; }
  }
}
