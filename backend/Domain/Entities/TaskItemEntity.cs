using TaskTracker.Domain.Enums;

namespace TaskTracker.Domain.Entities;

public class TaskItemEntity
{
    public Guid Id { get; init; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; init; }
    public TaskItemStatusEnum Status { get; private set; }

    public TaskItemEntity() { }

    public TaskItemEntity(string title, string description)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        CreatedAt = DateTime.UtcNow;
        Status = TaskItemStatusEnum.Pending;
    }

    public void Update(string description, TaskItemStatusEnum status)
    {
        Description = description;
        Status = status;
    }
}