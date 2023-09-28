using FluentValidation;
using System;

namespace BookStore.BookOperations.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator() 
        {
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(1);
            RuleFor(command => command.Model.GenreId).GreaterThan(0);         
            RuleFor(command => command.Model.PageCount).GreaterThan(20);
            RuleFor(command => command.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}
