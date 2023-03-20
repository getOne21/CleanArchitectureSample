using CleanArchitectureSample.Application.Common.Exceptions;
using CleanArchitectureSample.Application.Common.Interfaces;
using CleanArchitectureSample.Domain.Entities;
using MediatR;

namespace CleanArchitectureSample.Application.TodoItems.Commands.UpdateTodoItem;

public record UpdateTodoItemCommand : IRequest
{
    public int Id { get; init; }

    public string? Title { get; init; }

    public bool Done { get; init; }
}

public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand>
{
    private readonly IApplicationDbContext context;

    public UpdateTodoItemCommandHandler(IApplicationDbContext context) 
        => this.context = context;

    public async Task Handle(
        UpdateTodoItemCommand request, 
        CancellationToken cancellationToken)
    {
        var entity = await this.context.TodoItems.FindAsync(new object[] { request.Id }, cancellationToken) 
            ?? throw new NotFoundException(nameof(TodoItem), request.Id);

        entity.Title = request.Title;
        entity.Done = request.Done;

        await this.context.SaveChangesAsync(cancellationToken);
    }
}
