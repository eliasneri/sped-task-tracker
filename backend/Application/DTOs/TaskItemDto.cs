using TaskTracker.Domain.Enums;

namespace TaskTracker.Application.DTOs;

public record TaskItemDto(
    Guid Id,
    string Title,
    string  Description,
    DateTime CreatedAt,
    TaskItemStatusEnum Status
    );