using Catalog.Service.CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Service.CleanArchitecture.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
