using FluentValidation;

namespace CleanArchitectureSample.Application.TodoItems.Commands.CreateTodoItem;

public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
{
    public CreateTodoItemCommandValidator()
    {
        RuleFor(todoItemCommand => todoItemCommand.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}
