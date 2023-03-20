using System.Globalization;
using CleanArchitectureSample.Application.Common.Interfaces;
using CleanArchitectureSample.Application.TodoLists.Queries.ExportTodos;
using CleanArchitectureSample.Infrastructure.Files.Maps;
using CsvHelper;

namespace CleanArchitectureSample.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
            csvWriter.Context.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
