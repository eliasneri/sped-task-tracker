using TaskTracker.Application.DTOs;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Application.Services.Helpers;

public class TaskItemMapper
{
    public static TaskItemDto ToDto(TaskItemEntity entity)
    {
        return new TaskItemDto(
            entity.Id,
            entity.Title,
            entity.Description,
            entity.CreatedAt,
            entity.Status
        );
    }

    public static List<TaskItemDto> ToDtoList(List<TaskItemEntity> entities)
    {
        return entities.Select(ToDto).ToList();
    }
}