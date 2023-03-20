using System.Globalization;
using CleanArchitectureSample.Application.TodoLists.Queries.ExportTodos;
using CsvHelper.Configuration;

namespace CleanArchitectureSample.Infrastructure.Files.Maps;

public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        this.AutoMap(CultureInfo.InvariantCulture);
        this.Map(m => m.Done).Convert(c => c.Value.Done ? "Yes" : "No");
    }
}
