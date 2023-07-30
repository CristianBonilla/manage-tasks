using ManageTasks.Domain.Entities;
using ManageTasks.Domain.SeedWork.Collections;

namespace ManageTasks.Domain.SeedWork
{
  class SeedData
  {
    public static IEnumerable<TaskEntity> Tasks => TaskCollection.List;
  }
}
