
using FluentValidation;
using SchoolRegisterApp.Models.Dtos.SchoolDtos;
using SchoolRegisterApp.Repositories.CustomExceptions;

namespace SchoolRegisterApp.Repositories.Validations
{
    public class SchoolValidator : AbstractValidator<AddSchoolDto>
    {
        public const int InputLengthMax = 30;
        public const int InputLengthMin = 2;

        private const string NameRegex = @"^[А-я-]+$";

        public SchoolValidator()
        {
            RuleFor(x => x.Name)
                 .NotNull().WithState(a => new BadRequestException("Името е задължително"))
                 .MaximumLength(InputLengthMax).WithState(a => new BadRequestException($"Името не трябва да бъде по-малко от {InputLengthMax} символа"))
                 .MinimumLength(InputLengthMin).WithState(a => new BadRequestException($"Името не трябва да бъде повече от {InputLengthMin} символа"))
                 .Matches(NameRegex).WithState(a => new BadRequestException("Името трябва да бъде написано на кирилица"));

            RuleFor(x => x.NameAlt)
                 .NotNull().WithState(a => new BadRequestException("Името е задължително"))
                 .MaximumLength(InputLengthMax).WithState(a => new BadRequestException($"Презимето не трябва да бъде по-малко от {InputLengthMax} символа"))
                 .MinimumLength(InputLengthMin).WithState(a => new BadRequestException($"Презимето не трябва да бъде повече от {InputLengthMin} символа"));

            RuleFor(x => x.Type)
                 .NotNull().WithState(a => new BadRequestException("Типът е задължителен"));


            RuleFor(x => x.Settlement)
                 .NotNull().WithState(a => new BadRequestException("Населеното място е задължително"));

        }

    }
}
