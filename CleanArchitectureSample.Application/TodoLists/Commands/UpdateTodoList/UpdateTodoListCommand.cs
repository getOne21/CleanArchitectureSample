using CleanArchitectureSample.Application.Common.Exceptions;
using CleanArchitectureSample.Application.Common.Interfaces;
using CleanArchitectureSample.Domain.Entities;
using MediatR;

namespace CleanArchitectureSample.Application.TodoLists.Commands.UpdateTodoList;

public record UpdateTodoListCommand : IRequest
{
    public int Id { get; init; }

    public string? Title { get; init; }
}

public class UpdateTodoListCommandHandler : IRequestHandler<UpdateTodoListCommand>
{
    private readonly IApplicationDbContext context;

    public UpdateTodoListCommandHandler(IApplicationDbContext context) 
        => this.context = context;

    public async Task Handle(UpdateTodoListCommand request, CancellationToken cancellationToken)
    {
        var entity = await this.context.TodoLists.FindAsync(new object[] { request.Id }, cancellationToken) 
            ?? throw new NotFoundException(nameof(TodoList), request.Id);

        entity.Title = request.Title;

        await this.context.SaveChangesAsync(cancellationToken);
    }
}
