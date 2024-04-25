using Catalog.Service.CleanArchitecture.Application.Common.Mappings;
using Catalog.Service.CleanArchitecture.Domain.Entities;

namespace Catalog.Service.CleanArchitecture.Application.TodoItems.Queries.GetTodoItemsWithPagination;
public class TodoItemBriefDto : IMapFrom<TodoItem>
{
    public int Id { get; set; }

    public int ListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }
}
