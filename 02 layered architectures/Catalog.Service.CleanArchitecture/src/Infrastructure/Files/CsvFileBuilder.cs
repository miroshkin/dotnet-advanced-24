using System.Globalization;
using Catalog.Service.CleanArchitecture.Application.Common.Interfaces;
using Catalog.Service.CleanArchitecture.Application.TodoLists.Queries.ExportTodos;
using Catalog.Service.CleanArchitecture.Infrastructure.Files.Maps;
using CsvHelper;

namespace Catalog.Service.CleanArchitecture.Infrastructure.Files;
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
