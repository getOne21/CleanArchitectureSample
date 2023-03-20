using CleanArchitectureSample.Application.Common.Mappings;
using CleanArchitectureSample.Domain.Entities;

namespace CleanArchitectureSample.Application.TodoItems.Queries.GetTodoItemsWithPagination;

public class TodoItemBriefDto : IMapFrom<TodoItem>
{
    public int Id { get; init; }

    public int ListId { get; init; }

    public string? Title { get; init; }

    public bool Done { get; init; }
}
