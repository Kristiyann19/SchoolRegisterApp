using FluentValidation;
using SchoolRegisterApp.Models.Dtos.PersonSchoolDtos;
using SchoolRegisterApp.Repositories.CustomExceptions;

namespace SchoolRegisterApp.Repositories.Validations
{
    public class PersonSchoolAddValidator : AbstractValidator<PersonSchoolAddDto>
    {
        public PersonSchoolAddValidator()
        {
            RuleFor(x => x.Position)
                .IsInEnum().WithState(a => new BadRequestException("Невалидна позиция"));

            RuleFor(x => x.PersonId)
                 .NotNull().WithState(a => new BadRequestException("Преподавателят е задължителен"));

            RuleFor(x => x.SchoolId)
                 .NotNull().WithState(a => new BadRequestException("Училището е задължително"));

            RuleFor(x => x.StartDate)
                .GreaterThan(DateTime.UtcNow).WithState(a => new BadRequestException("Началната дата не може да бъде минала или днешна дата"));

            RuleFor(x => x.EndDate)
                .GreaterThan(DateTime.UtcNow).WithState(a => new BadRequestException("Крайната не може да бъде минала или днешна дата"));
        }
    }
}
