using Microsoft.EntityFrameworkCore;
using TaskTracker.Application.Interfaces;
using TaskTracker.Domain.Entities;
using TaskTracker.Infrastructure.Data;

namespace TaskTracker.Infrastructure.Repositories;

public class TaskItemRepository : ITaskRepository
{
    private readonly AppDbContext _dbContext;

    public TaskItemRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<TaskItemEntity>> GetAllTasks()
    {
        return await _dbContext.Tasks.ToListAsync();
    }

    public async Task<TaskItemEntity?> GetTaskById(Guid id)
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