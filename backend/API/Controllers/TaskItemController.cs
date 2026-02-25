
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Application.DTOs;
using TaskTracker.Application.Interfaces;
using TaskTracker.Application.Utils;

namespace TaskTracker.API.Controllers;

[ApiController]
[Route(ParametersGlobals.Prefix + "/tasks")]
public class TaskItemController : ControllerBase
{
    private readonly ITaskItemService _service;

    public TaskItemController(ITaskItemService service)
    {
        _service = service;
    }

    ///<summary>
    /// Retorna todas as Tarefas
    /// </summary>
    [HttpGet("findall")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<TaskItemDto>>> GetAllTasksAsync()
    {
        var tasks = await _service.GetAllTasksAsync();
        return Ok(tasks);
        
    }

    /// <summary>
    ///  Retorna todas uma tarefa buscando pelo Id
    ///  </summary>
    /// <param name="id"></param>
    [HttpGet("findby/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<TaskItemDto>>> GetByIdTaskAsync(Guid id)
    {
        var task = await _service.GetTaskByIdAsync(id);

        if (task is null)
            return NotFound(new { message = $"Task with id: {id} not found!" });

        return Ok(task);
    }
    
}