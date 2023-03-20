using CleanArchitectureSample.Application.TodoLists.Queries.ExportTodos;

namespace CleanArchitectureSample.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
