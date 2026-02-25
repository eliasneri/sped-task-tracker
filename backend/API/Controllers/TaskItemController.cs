
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
    ///  Retorna uma tarefa buscando pelo Id
    ///  </summary>
    /// <param name="id"></param>
    [HttpGet("findby/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<TaskItemDto>>> GetByIdTaskAsync(Guid id)
    {
        var task = await _service.GetTaskByIdAsync(id);

        if (task is null)
            return NotFound(new { message = $"Task with id: {id} not found!" });

        return Ok(task);
    }
    
    /// <summary>
    /// Cria uma nova tarefa
    /// </summary>
    [HttpPost("new")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> AddTaskAsync(CreateTaskItemDto dto)
    {
        var created = await _service.AddTaskAsync(dto);
        return Ok(created);
    }
    
    /// <summary>
    /// Atualiza uma tarefa
    /// </summary>
    [HttpPut("update/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateTaskAsync(Guid id, UpdateTaskItemDto dto)
    {
        await _service.UpdateTaskAsync(id, dto);
        return NoContent();
    }

    /// <summary>
    /// Remove uma tarefa
    /// </summary>
    [HttpDelete("delete/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteTaskAsync(Guid id)
    {
        await _service.DeleteTaskAsync(id);
        return NoContent();
    }
}