using FluentValidation;

namespace CleanArchitectureSample.Application.TodoItems.Commands.UpdateTodoItem;

public class UpdateTodoItemCommandValidator : AbstractValidator<UpdateTodoItemCommand>
{
    public UpdateTodoItemCommandValidator()
    {
        RuleFor(command => command.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}
