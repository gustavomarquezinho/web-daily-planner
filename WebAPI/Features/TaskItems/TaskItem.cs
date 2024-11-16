using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Features.TaskItems.Enums;

namespace WebAPI.Features.TaskItems;

public class TaskItem
{
    public int Id { get; init; }
    public required string Title { get; init; }
    public string? Description { get; init; }
    public required DateTimeOffset CreateDate { get; init; } = DateTimeOffset.UtcNow;
    public required DateTimeOffset DueDate { get; init; }
    public required DateTimeOffset? CompletionDate { get; init; }
    public required TaskItemStatus Status { get; init; } = TaskItemStatus.Pending;

    [NotMapped]
    public bool IsCompleted => CompletionDate is not null || Status == TaskItemStatus.Completed;
}
