using FluentValidation;
using WordLadder.Exercise.Contracts.DTOs;
using WordLadder.Exercise.Misc;

namespace WordLadder.Exercise.Validators
{
    public class StartWordDtoValidator : AbstractValidator<StartWordDto>
    {
        public StartWordDtoValidator()
        {
            RuleFor(x => x.StartWord)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                    .WithErrorCode(Constants.RunRequestValidationErrorMessages.StartWordCannotBeNull)
                    .WithMessage(Constants.RunRequestValidationErrorMessages.StartWordCannotBeNull)
                .NotEmpty()
                    .WithErrorCode(Constants.RunRequestValidationErrorMessages.StartWordCannotBeEmpty)
                    .WithMessage(Constants.RunRequestValidationErrorMessages.StartWordCannotBeEmpty)
                .Length(Constants.ExpectedWordSize)
                    .WithErrorCode(Constants.RunRequestValidationErrorMessages.StartWordMustHaveExpectedLength)
                    .WithMessage(Constants.RunRequestValidationErrorMessages.StartWordMustHaveExpectedLength);
        }
    }
}
