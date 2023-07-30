using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ManageTasks.Domain.Entities;
using ManageTasks.Domain.SeedWork;

namespace ManageTasks.Domain.EntitiesConfig
{
  class TaskConfig : IEntityTypeConfiguration<TaskEntity>
  {
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
    {
      builder.ToTable("Task", "dbo")
        .HasKey(key => key.TaskId);
      builder.Property(property => property.TaskId)
        .HasDefaultValueSql("NEWID()");
      builder.Property(property => property.TaskAction)
        .HasMaxLength(50)
        .IsUnicode()
        .IsRequired();
      builder.Property(property => property.Status)
        .IsRequired();
      builder.HasData(SeedData.Tasks);
    }
  }
}
