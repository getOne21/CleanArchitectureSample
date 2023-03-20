using CleanArchitectureSample.Application.Common.Exceptions;
using CleanArchitectureSample.Application.Common.Interfaces;
using CleanArchitectureSample.Domain.Entities;
using CleanArchitectureSample.Domain.Events;
using MediatR;

namespace CleanArchitectureSample.Application.TodoItems.Commands.DeleteTodoItem;

public record DeleteTodoItemCommand(int Id) : IRequest;

public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
{
    private readonly IApplicationDbContext context;

    public DeleteTodoItemCommandHandler(IApplicationDbContext context)
        => this.context = context;

    public async Task Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await this.context.TodoItems.FindAsync(new object[] { request.Id }, cancellationToken) 
            ?? throw new NotFoundException(nameof(TodoItem), request.Id);

        this.context.TodoItems.Remove(entity);

        entity.AddDomainEvent(new TodoItemDeletedEvent(entity));

        await this.context.SaveChangesAsync(cancellationToken);
    }
}
