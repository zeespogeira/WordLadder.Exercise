using FluentValidation;
using WordLadder.Exercise.Contracts.DTOs;
using WordLadder.Exercise.Misc;

namespace WordLadder.Exercise.Validators
{
    public class ResultFileDtoValidator : AbstractValidator<ResultFileDto>
    {
        public ResultFileDtoValidator()
        {
            RuleFor(x => x.FileName)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                    .WithErrorCode(Constants.RunRequestValidationErrorMessages.ResultFileNameCannotBeNull)
                    .WithMessage(Constants.RunRequestValidationErrorMessages.ResultFileNameCannotBeNull)
                .NotEmpty()
                    .WithErrorCode(Constants.RunRequestValidationErrorMessages.ResultFileNameCannotBeEmpty)
                    .WithMessage(Constants.RunRequestValidationErrorMessages.ResultFileNameCannotBeEmpty);
        }
    }
}
