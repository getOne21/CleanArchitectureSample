using CleanArchitectureSample.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitectureSample.Application.TodoItems.EventHandlers;

public class TodoItemCompletedEventHandler : INotificationHandler<TodoItemCompletedEvent>
{
    private readonly ILogger<TodoItemCompletedEventHandler> logger;

    public TodoItemCompletedEventHandler(ILogger<TodoItemCompletedEventHandler> logger) 
        => this.logger = logger;

    public Task Handle(TodoItemCompletedEvent notification, CancellationToken cancellationToken)
    {
        this.logger.LogInformation(
            "CleanArchitecture Domain Event: {DomainEvent}", 
            notification.GetType().Name);

        return Task.CompletedTask;
    }
}
