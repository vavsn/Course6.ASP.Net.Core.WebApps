using FluentValidation;
using FluentValidation.Results;
using TimeSheets.DAL.Models;

namespace TimeSheets.DAL.Validation
{
    public class PersonVallidationService : AbstractValidator<Person>
    {
        private readonly IPersonService _personService;

        public PersonVallidationService(IPersonService personService)
        {
            _personService = personService;

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Имя не должно быть пустым")
                .WithErrorCode("P01");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Фамилия не должна быть пустым")
                .WithErrorCode("P02");

            RuleFor(x => x.Email).Custom((s, context) =>
            {
                if (s.IndexOf("@") ==0)
                {
                    context.AddFailure(new ValidationFailure(
                        nameof(s), "Неверный Email адрес: адрес должен содержать символ @")
                    {
                        ErrorCode = "P03.01"
                    });
                }
            });
        }
    }
}
