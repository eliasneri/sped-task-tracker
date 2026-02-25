using TaskTracker.Domain.Entities;

namespace TaskTracker.Application.Interfaces;

public interface ITaskItemRepository
{
    Task<List<TaskItemEntity>> GetAllTasksAsync();
    Task<TaskItemEntity?> GetTaskByIdAsync(Guid id);
    Task AddTaskAsync(TaskItemEntity task);
    Task UpdateTaskAsync(TaskItemEntity task);
    Task DeleteTaskAsync(TaskItemEntity task);
}