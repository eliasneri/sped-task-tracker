using TaskTracker.Domain.Enums;

namespace TaskTracker.Application.DTOs;

public record UpdateTaskItemDto(string Description, TaskItemStatusEnum Status);