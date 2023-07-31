namespace ManageTasks.Domain.Entities
{
  public class TaskEntity
  {
    public Guid TaskId { get; set; }
    public string TaskAction { get; set; } = null!;
    public TaskProgressStatus Status { get; set; }
    public DateTimeOffset Created { get; set; }
    public byte[] Version { get; set; } = null!;
  }
}
