using CleanArchitectureSample.Application.Common.Mappings;
using CleanArchitectureSample.Domain.Entities;

namespace CleanArchitectureSample.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; init; }

    public bool Done { get; init; }
}
