using TaskTracker.Domain.Entities;

namespace TaskTracker.Application.Interfaces;

public interface ITaskItemRepository
{
    Task<List<TaskItemEntity>> GetAllTasksAsync();
    Task<TaskItemEntity?> GetTaskByIdAsync(Guid id);
    Task <TaskItemEntity>AddTaskAsync(TaskItemEntity task);
    Task<TaskItemEntity> UpdateTaskAsync(TaskItemEntity task);
    Task <bool>DeleteTaskAsync(TaskItemEntity task);
}