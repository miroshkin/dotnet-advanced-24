using Catalog.Service.CleanArchitecture.Application.Common.Exceptions;
using Catalog.Service.CleanArchitecture.Application.TodoLists.Commands.CreateTodoList;
using Catalog.Service.CleanArchitecture.Application.TodoLists.Commands.DeleteTodoList;
using Catalog.Service.CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

using static Testing;

namespace Catalog.Service.CleanArchitecture.Application.IntegrationTests.TodoLists.Commands;
public class DeleteTodoListTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoListId()
    {
        var command = new DeleteTodoListCommand(99);
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoList()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        await SendAsync(new DeleteTodoListCommand(listId));

        var list = await FindAsync<TodoList>(listId);

        list.Should().BeNull();
    }
}
