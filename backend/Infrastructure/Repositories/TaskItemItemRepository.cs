using Microsoft.EntityFrameworkCore;
using TaskTracker.Application.Interfaces;
using TaskTracker.Domain.Entities;
using TaskTracker.Infrastructure.Data;

namespace TaskTracker.Infrastructure.Repositories;

public class TaskItemItemRepository : ITaskItemRepository
{
    private readonly AppDbContext _dbContext;

    public TaskItemItemRepository(AppDbContext dbContext)
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

    public async Task AddTaskAsync(TaskItemEntity task)
    {
        await _dbContext.Tasks.AddAsync(task);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateTaskAsync(TaskItemEntity task)
    {
        _dbContext.Tasks.Update(task);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteTaskAsync(TaskItemEntity task)
    {
     _dbContext.Tasks.Remove(task);
     await _dbContext.SaveChangesAsync();
    }
}