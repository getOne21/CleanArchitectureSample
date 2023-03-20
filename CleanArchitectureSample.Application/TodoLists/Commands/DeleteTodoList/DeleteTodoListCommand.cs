using CleanArchitectureSample.Application.Common.Exceptions;
using CleanArchitectureSample.Application.Common.Interfaces;
using CleanArchitectureSample.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureSample.Application.TodoLists.Commands.DeleteTodoList;

public record DeleteTodoListCommand(int Id) : IRequest;

public class DeleteTodoListCommandHandler : IRequestHandler<DeleteTodoListCommand>
{
    private readonly IApplicationDbContext context;

    public DeleteTodoListCommandHandler(IApplicationDbContext context) 
        => this.context = context;

    public async Task Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
    {
        var entity = await this.context.TodoLists
            .Where(entity => entity.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken)
            ?? throw new NotFoundException(nameof(TodoList), request.Id);

        this.context.TodoLists.Remove(entity);

        await this.context.SaveChangesAsync(cancellationToken);
    }
}
