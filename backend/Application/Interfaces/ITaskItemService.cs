using TaskTracker.Application.DTOs;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Application.Interfaces;

public interface ITaskItemService
{
    Task<List<TaskItemDto>> GetAllTasksAsync();
    Task<TaskItemDto?> GetTaskByIdAsync(Guid id);
    Task <TaskItemDto> AddTaskAsync(CreateTaskItemDto dto);
    Task <TaskItemDto>UpdateTaskAsync(Guid id, UpdateTaskItemDto dto);
    Task <bool>DeleteTaskAsync(Guid id);
}