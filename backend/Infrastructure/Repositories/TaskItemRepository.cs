using Microsoft.EntityFrameworkCore;
using TaskTracker.Application.Interfaces;
using TaskTracker.Domain.Entities;
using TaskTracker.Infrastructure.Data;

namespace TaskTracker.Infrastructure.Repositories;

public class TaskItemRepository : ITaskItemRepository
{
    private readonly AppDbContext _dbContext;

    public TaskItemRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<TaskItemEntity>> GetAllTasksAsync()
    {
        return await _dbContext.Tasks.ToListAsync();
    }

    public async Task<TaskItemEntity?> GetTaskByIdAsync(Guid id)
    {
        return await _dbContext.Tasks.FindAsync(id);
    }

    public async Task<TaskItemEntity> AddTaskAsync(TaskItemEntity task)
    {
        await _dbContext.Tasks.AddAsync(task);
        await _dbContext.SaveChangesAsync();

        return task;
    }

    public async Task<TaskItemEntity> UpdateTaskAsync(TaskItemEntity task)
    {
        await _dbContext.SaveChangesAsync();
        return task;
    }

    public async Task<bool> DeleteTaskAsync(TaskItemEntity task)
    {
     _dbContext.Tasks.Remove(task);
     var affRows = await _dbContext.SaveChangesAsync();
     return affRows > 0;
    }
}