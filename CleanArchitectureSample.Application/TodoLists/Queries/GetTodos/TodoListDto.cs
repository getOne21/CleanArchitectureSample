using CleanArchitectureSample.Application.Common.Mappings;
using CleanArchitectureSample.Domain.Entities;

namespace CleanArchitectureSample.Application.TodoLists.Queries.GetTodos;

public class TodoListDto : IMapFrom<TodoList>
{
    public TodoListDto() 
        => this.Items = Array.Empty<TodoItemDto>();

    public int Id { get; init; }

    public string? Title { get; init; }

    public string? Colour { get; init; }

    public IReadOnlyCollection<TodoItemDto> Items { get; init; }
}
