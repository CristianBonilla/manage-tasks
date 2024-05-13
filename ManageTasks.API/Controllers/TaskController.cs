using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ManageTasks.Contracts.DTO.Task;
using ManageTasks.Contracts.Services;
using ManageTasks.Domain.Entities;

namespace ManageTasks.API.Controllers
{
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiController]
  [ApiVersion("1.0")]
  [Produces("application/json")]
  public class TaskController : ControllerBase
  {
    readonly IMapper _mapper;
    readonly ITaskService _service;

    public TaskController(IMapper mapper, ITaskService service)
    {
      _mapper = mapper;
      _service = service;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TaskResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddTask([FromBody] TaskRequest taskRequest)
    {
      TaskEntity task = _mapper.Map<TaskEntity>(taskRequest);
      TaskEntity addedTask = await _service.AddTask(task);
      TaskResponse taskResponse = _mapper.Map<TaskResponse>(addedTask);

      return CreatedAtAction(nameof(AddTask), taskResponse);
    }

    [HttpPut("{taskId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateTask(Guid taskId, [FromBody] TaskRequest taskRequest)
    {
      TaskEntity task = await _service.UpdateTask(taskId, taskRequest.Action, taskRequest.Status);
      TaskResponse taskResponse = _mapper.Map<TaskResponse>(task);

      return Ok(taskResponse);
    }

    [HttpDelete("{taskId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteTask(Guid TaskId)
    {
      _ = await _service.DeleteTask(TaskId);

      return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IAsyncEnumerable<TaskResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async IAsyncEnumerable<TaskResponse> Get()
    {
      var tasks = _service.GetTasks();
      await foreach (TaskEntity task in tasks)
        yield return _mapper.Map<TaskResponse>(task);
    }
  }
}
