﻿using CleanArchitectureSample.Application.Common.Interfaces;
using CleanArchitectureSample.Domain.Entities;
using CleanArchitectureSample.Domain.Events;
using MediatR;

namespace CleanArchitectureSample.Application.TodoItems.Commands.CreateTodoItem;

public record CreateTodoItemCommand : IRequest<int>
{
    public int ListId { get; init; }

    public string? Title { get; init; }
}

public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, int>
{
    private readonly IApplicationDbContext context;

    public CreateTodoItemCommandHandler(IApplicationDbContext context) 
        => this.context = context;

    public async Task<int> Handle(
        CreateTodoItemCommand request, 
        CancellationToken cancellationToken)
    {
        var entity = new TodoItem
        {
            ListId = request.ListId,
            Title = request.Title,
            Done = false
        };

        entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

        this.context.TodoItems.Add(entity);

        await this.context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
