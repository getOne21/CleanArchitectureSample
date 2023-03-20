﻿namespace CleanArchitectureSample.Domain.Entities;

public class TodoItem : BaseAuditableEntity
{
    public int ListId { get; set; }

    public string? Title { get; set; }

    public string? Note { get; set; }

    public PriorityLevel Priority { get; set; }

    public DateTime? Reminder { get; set; }

    private bool done;
    public bool Done
    {
        get => this.done;
        set
        {
            if (value && !this.done)
            {
                AddDomainEvent(new TodoItemCompletedEvent(this));
            }

            this.done = value;
        }
    }

    public TodoList List { get; set; } = null!;
}
