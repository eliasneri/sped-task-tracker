using TaskTracker.Application.DTOs;
using TaskTracker.Application.Interfaces;
using TaskTracker.Application.Services.Helpers;
using TaskTracker.Domain.Entities;
using TaskTracker.Domain.Exceptions;

namespace TaskTracker.Application.Services;

public class TaskItemService : TaskItemMapper, ITaskItemService
{
    
    private readonly ITaskItemRepository repository;
    

    public TaskItemService(ITaskItemRepository repository)
    {
        this.repository = repository;
    }
        
    
    // all
    public async Task<List<TaskItemDto>> GetAllTasksAsync()
    {
        var tasks = await repository.GetAllTasksAsync();
        return ToDtoList(tasks);
    }

    // By id
    public async Task<TaskItemDto?> GetTaskByIdAsync(Guid id)
    {
        var task = await repository.GetTaskByIdAsync(id);

        if (task is null)
            return null;

        return ToDto(task);
    }

    // Create task
    public async Task<TaskItemDto> AddTaskAsync(CreateTaskItemDto dto)
    {
        var task = new TaskItemEntity(dto.Title, dto.Description);
        var newTask = await repository.AddTaskAsync(task);
        return ToDto(newTask);
    }

    // Update Task!
    public async Task<TaskItemDto> UpdateTaskAsync(Guid id, UpdateTaskItemDto dto)
    {
        var task = await repository.GetTaskByIdAsync(id);

        if (task is null)
            throw new DomainException($"Task {id} not found!");
        
        task.EnsureCanModify();
        task.Update(dto.Description, dto.Status);
        
        var updateTask = await repository.UpdateTaskAsync(task);

        return ToDto(updateTask);

    }

    // Delete!
    public async Task<bool> DeleteTaskAsync(Guid id)
    {
        var task = await repository.GetTaskByIdAsync(id);
        
        if (task is null)
            throw new DomainException($"Task {id} not found!");
        
        task.EnsureCanModify();

        return await repository.DeleteTaskAsync(task);
    }
}