using FluentValidation;
using WordLadder.Exercise.Contracts.DTOs;
using WordLadder.Exercise.Contracts.Interfaces;
using WordLadder.Exercise.Misc;

namespace WordLadder.Exercise.Validators
{
    public class WordFileDtoValidator : AbstractValidator<WordFileDto>
    {
        private readonly IFileValidator _fileValidator;

        public WordFileDtoValidator(IFileValidator fileValidator)
        {
            _fileValidator = fileValidator;
            RuleFor(x => x.Path)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                    .WithErrorCode(Constants.RunRequestValidationErrorMessages.WordFilePathCannotBeNull)
                    .WithMessage(Constants.RunRequestValidationErrorMessages.WordFilePathCannotBeNull)
                .NotEmpty()
                    .WithErrorCode(Constants.RunRequestValidationErrorMessages.WordFilePathCannotBeEmpty)
                    .WithMessage(Constants.RunRequestValidationErrorMessages.WordFilePathCannotBeEmpty)
                .Must(Exist)
                    .WithErrorCode(Constants.RunRequestValidationErrorMessages.WordFilePathMustExist)
                    .WithMessage(Constants.RunRequestValidationErrorMessages.WordFilePathMustExist);
        }

        private bool Exist(string filePath)
        {
            return _fileValidator.FileExist(filePath);
        }
    }
}
