using Catalog.Service.CleanArchitecture.Application.Common.Mappings;
using Catalog.Service.CleanArchitecture.Domain.Entities;

namespace Catalog.Service.CleanArchitecture.Application.TodoLists.Queries.GetTodos;
public class TodoListDto : IMapFrom<TodoList>
{
    public TodoListDto()
    {
        Items = new List<TodoItemDto>();
    }

    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Colour { get; set; }

    public IList<TodoItemDto> Items { get; set; }
}
