using AutoMapper;
using ManageTasks.Contracts.DTO.Task;
using ManageTasks.Domain.Entities;

namespace ManageTasks.API.Mappings.Profiles
{
  class ManageTasksProfile : Profile
  {
    public ManageTasksProfile()
    {
      CreateMap<TaskRequest, TaskEntity>()
        .ForMember(member => member.TaskId, options => options.Ignore())
        .ForMember(member => member.Created, options => options.Ignore())
        .ForMember(member => member.Version, options => options.Ignore());
      CreateMap<TaskEntity, TaskResponse>()
        .ReverseMap()
        .ForMember(member => member.Version, options => options.Ignore());
    }
  }
}
