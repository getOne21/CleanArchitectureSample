using CleanArchitectureSample.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitectureSample.Application.TodoItems.EventHandlers;

public class TodoItemCreatedEventHandler : INotificationHandler<TodoItemCreatedEvent>
{
    private readonly ILogger<TodoItemCreatedEventHandler> logger;

    public TodoItemCreatedEventHandler(ILogger<TodoItemCreatedEventHandler> logger) 
        => this.logger = logger;

    public Task Handle(TodoItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        this.logger.LogInformation(
            "CleanArchitecture Domain Event: {DomainEvent}", 
            notification.GetType().Name);

        return Task.CompletedTask;
    }
}
