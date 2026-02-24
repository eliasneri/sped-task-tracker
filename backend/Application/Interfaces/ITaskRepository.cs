using TaskTracker.Domain.Entities;

namespace TaskTracker.Application.Interfaces;

public interface ITaskRepository
{
    Task<List<TaskItemEntity>> GetAllTasks();
    Task<TaskItemEntity?> GetTaskById(Guid id);
    Task AddTaskAsync(TaskItemEntity task);
    Task UpdateTaskAsync(TaskItemEntity task);
    Task DeleteTaskAsync(TaskItemEntity task);
}