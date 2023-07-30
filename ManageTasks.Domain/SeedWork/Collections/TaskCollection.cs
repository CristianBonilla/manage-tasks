using ManageTasks.Contracts.DTO;
using ManageTasks.Domain.Entities;

namespace ManageTasks.Domain.SeedWork.Collections
{
  class TaskCollection
  {
    public static IEnumerable<TaskEntity> List => new TaskEntity[]
    {
      new()
      {
        TaskId = new Guid("5D84ED88-8078-4825-B740-02BD71D5346A"),
        TaskAction = "Tocar la guitarra",
        Status = TaskProgressStatus.NotCompleted,
        Created = new DateTimeOffset(2023, 5, 11, 15, 30, 0, TimeSpan.FromHours(3)),
      },
      new()
      {
        TaskId = new Guid("A9741F3A-BAEA-4211-90DE-F2FA53C9CAA2"),
        TaskAction = "Practicar la calistenia",
        Status = TaskProgressStatus.NotCompleted,
        Created = new DateTimeOffset(2023, 6, 8, 10, 42, 10, TimeSpan.FromHours(3)),
      },
      new()
      {
        TaskId = new Guid("EF839C0B-0E57-4BBE-BE29-BE1C501E82BB"),
        TaskAction = "Leer \"Menos miedos más Riquezas\"",
        Status = TaskProgressStatus.Completed,
        Created = new DateTimeOffset(2023, 7, 1, 12, 0, 44, TimeSpan.FromHours(3)),
      },
      new()
      {
        TaskId = new Guid("24E01E15-3F23-49E0-B177-0B325EC2AF9C"),
        TaskAction = "Meditar en la noche",
        Status = TaskProgressStatus.NotCompleted,
        Created = new DateTimeOffset(2023, 7, 17, 19, 27, 50, TimeSpan.FromHours(3)),
      },
      new()
      {
        TaskId = new Guid("49CF31BA-32DC-4DED-817C-F9B5C71C968C"),
        TaskAction = "Pasear a mi Pit Bull",
        Status = TaskProgressStatus.Completed,
        Created = new DateTimeOffset(2023, 7, 28, 11, 0, 0, TimeSpan.FromHours(3)),
      }
    };

    public Guid this[int index] => List.ElementAt(index).TaskId;
  }
}
