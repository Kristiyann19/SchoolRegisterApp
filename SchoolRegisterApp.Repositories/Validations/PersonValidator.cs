using FluentValidation;
using SchoolRegisterApp.Models.Dtos.PersonDtos;
using SchoolRegisterApp.Repositories.CustomExceptions;

namespace SchoolRegisterApp.Repositories.Validations
{
    public class PersonValidator : AbstractValidator<PersonDetailsDto>
    {
        public const int InputLengthMax = 30;
        public const int InputLengthMin = 2;

        private const string NameRegex = @"^[А-я-]+$";
        private const string UicRegex = @"^\d{10}$";

        public PersonValidator()
        {
            RuleFor(x => x.FirstName)
                 .NotNull().WithState(a => new BadRequestException("Името е задължително"))
                 .MaximumLength(InputLengthMax).WithState(a => new BadRequestException($"Името не трябва да бъде повече от {InputLengthMax} символа"))
                 .MinimumLength(InputLengthMin).WithState(a => new BadRequestException($"Името не трябва да бъде по-малко от {InputLengthMin} символа"))
                 .Matches(NameRegex).WithState(a => new BadRequestException("Името трябва да бъде написано на кирилица"));

            RuleFor(x => x.MiddleName)
                 .NotNull().WithState(a => new BadRequestException("Презимето е задължително"))
                 .MaximumLength(InputLengthMax).WithState(a => new BadRequestException($"Презимето не трябва да бъде повече от {InputLengthMax} символа"))
                 .MinimumLength(InputLengthMin).WithState(a => new BadRequestException($"Презимето не трябва да бъде по-малко от {InputLengthMin} символа"))
                 .Matches(NameRegex).WithState(a => new BadRequestException("Презимето трябва да бъде написано на кирилица"));

            RuleFor(x => x.LastName)
                 .NotNull().WithState(a => new BadRequestException("Фамилията е задължителна"))
                 .MaximumLength(InputLengthMax).WithState(a => new BadRequestException($"Фамилията не трябва да бъде повече от {InputLengthMax} символа"))
                 .MinimumLength(InputLengthMin).WithState(a => new BadRequestException($"Фамилията не трябва да бъде по-малко от {InputLengthMin} символа"))
                 .Matches(NameRegex).WithState(a => new BadRequestException("Фамилията трябва да бъде написана на кирилица"));

            RuleFor(x => x.Uic)
                 .NotNull().WithState(a => new BadRequestException("ЕГН е задължително"))
                 .Matches(UicRegex).WithState(a => new BadRequestException("Неправилен формат на ЕГН"));

            RuleFor(x => x.BirthPlaceId)
                 .NotNull().WithState(a => new BadRequestException("Месторождението е задължително"));
        }
    }
}
