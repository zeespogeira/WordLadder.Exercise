using FluentValidation;
using WordLadder.Exercise.Contracts.DTOs;
using WordLadder.Exercise.Misc;

namespace WordLadder.Exercise.Validators
{
    public class EndWordDtoValidator : AbstractValidator<EndWordDto>
    {
        public EndWordDtoValidator()
        {
            RuleFor(x => x.EndWord)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                    .WithErrorCode(Constants.RunRequestValidationErrorMessages.EndWordCannotBeNull)
                    .WithMessage(Constants.RunRequestValidationErrorMessages.EndWordCannotBeNull)
                .NotEmpty()
                    .WithErrorCode(Constants.RunRequestValidationErrorMessages.EndWordCannotBeEmpty)
                    .WithMessage(Constants.RunRequestValidationErrorMessages.EndWordCannotBeEmpty)
                .Length(Constants.ExpectedWordSize)
                    .WithErrorCode(Constants.RunRequestValidationErrorMessages.EndWordMustHaveExpectedLength)
                    .WithMessage(Constants.RunRequestValidationErrorMessages.EndWordMustHaveExpectedLength);
            ;
        }
    }
}
