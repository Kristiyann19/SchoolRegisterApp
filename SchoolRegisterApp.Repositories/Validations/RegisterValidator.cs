using FluentValidation;
using SchoolRegisterApp.Models.Dtos.UserDtos;
using SchoolRegisterApp.Repositories.CustomExceptions;

namespace SchoolRegisterApp.Models.Validations
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public const int InputLengthMax = 30;
        public const int InputLengthMin = 2;
        public const string PhoneRegEx = "^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$";

        public RegisterValidator()
        {
            RuleFor(x => x.Username)
                 .NotNull().WithState(a => new BadRequestException("Името е задължително"))
                 .MaximumLength(InputLengthMax).WithState(a => new BadRequestException($"Името не трябва да бъде повече от {InputLengthMax} символа"))
                 .MinimumLength(InputLengthMin).WithState(a => new BadRequestException($"Името не трябва да бъде по-малко от {InputLengthMin} символа"));

            RuleFor(x => x.Password)
                 .NotNull().WithState(a => new BadRequestException("Паролата е задължителна"))
                 .MaximumLength(InputLengthMax).WithState(a => new BadRequestException($"Паролата не трябва да бъде повече от {InputLengthMax} символа"))
                 .MinimumLength(InputLengthMin).WithState(a => new BadRequestException($"Паролата не трябва да бъде по-малко от {InputLengthMin} символа"));

            RuleFor(x => x.ConfirmPassword)
                .NotNull().WithState(a => new BadRequestException("Паролата е задължителна"))
                .MaximumLength(InputLengthMax)
                .MinimumLength(InputLengthMin)
                .Equal(x => x.Password).WithState(a => new BadRequestException("Паролите не съвпадат"));

            RuleFor(x => x.Phone)
                .NotEmpty().WithState(a => new BadRequestException("Телефонът е задължителен"))
                .Matches(PhoneRegEx);
     
        }
    }
}
