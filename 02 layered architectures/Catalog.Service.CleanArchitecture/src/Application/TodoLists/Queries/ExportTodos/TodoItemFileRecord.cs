using Catalog.Service.CleanArchitecture.Application.Common.Mappings;
using Catalog.Service.CleanArchitecture.Domain.Entities;

namespace Catalog.Service.CleanArchitecture.Application.TodoLists.Queries.ExportTodos;
public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
