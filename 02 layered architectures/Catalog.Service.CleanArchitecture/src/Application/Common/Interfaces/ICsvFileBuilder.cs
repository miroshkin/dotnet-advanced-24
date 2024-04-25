using Catalog.Service.CleanArchitecture.Application.TodoLists.Queries.ExportTodos;

namespace Catalog.Service.CleanArchitecture.Application.Common.Interfaces;
public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
