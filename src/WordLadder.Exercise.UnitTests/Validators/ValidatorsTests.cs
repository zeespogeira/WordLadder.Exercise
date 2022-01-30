using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Moq;
using NUnit.Framework;
using WordLadder.Exercise.Contracts.DTOs;
using WordLadder.Exercise.Contracts.Interfaces;
using WordLadder.Exercise.Misc;
using WordLadder.Exercise.Validators;

namespace WordLadder.Exercise.UnitTests.Validators
{
    /// <summary>
    /// This class implements test on DTOs validators 
    /// </summary>
    public class ValidatorsTests
    {
        [TestCaseSource(nameof(GetStartWordDtoValidatorCases))]
        public void Test_StartWordDtoValidator_should_validate_as_expected(StartWordDto dto, string expectedErrorCode)
        {
            //arrange
            var sut = new StartWordDtoValidator();

            //act
            var validationResult = sut.Validate(dto);

            //assert
            if (string.IsNullOrEmpty(expectedErrorCode))
            {
                AssertShouldNotHaveErrors(validationResult);
            }
            else
            {
                AssertShouldNotCascade(validationResult);
                AssertShouldHaveExpectedErrorCode(validationResult, expectedErrorCode);
            }
        }

        [TestCaseSource(nameof(GetWordFileDtoValidatorCases))]
        public void Test_WordFileDtoValidator(WordFileDto dto, bool fileExists, string expectedErrorCode)
        {
            //arrange
            var fileValidatorMock = new Mock<IFileValidator>();
            fileValidatorMock.Setup(x => x.FileExist(dto.Path)).Returns(() => fileExists);

            var sut = new WordFileDtoValidator(fileValidatorMock.Object);

            //act
            var validationResult = sut.Validate(dto);

            //assert
            if (string.IsNullOrEmpty(expectedErrorCode))
            {
                AssertShouldNotHaveErrors(validationResult);
            }
            else
            {
                AssertShouldNotCascade(validationResult);
                AssertShouldHaveExpectedErrorCode(validationResult, expectedErrorCode);
            }
        }

        [TestCaseSource(nameof(GetEndWordDtoValidatorCases))]
        public void Test_EndWordDtoValidator(EndWordDto dto, string expectedErrorCode)
        {
            //arrange
            var sut = new EndWordDtoValidator();

            //act
            var validationResult = sut.Validate(dto);


            //assert
            if (string.IsNullOrEmpty(expectedErrorCode))
            {
                AssertShouldNotHaveErrors(validationResult);
            }
            else
            {
                AssertShouldNotCascade(validationResult);
                AssertShouldHaveExpectedErrorCode(validationResult, expectedErrorCode);
            }

        }

        [TestCaseSource(nameof(GetResultFileDtoValidatorCases))]
        public void Test_ResultFileDtoValidator(ResultFileDto dto, string expectedErrorCode)
        {
            //arrange
            var sut = new ResultFileDtoValidator();

            //act
            var validationResult = sut.Validate(dto);

            //assert
            if (string.IsNullOrEmpty(expectedErrorCode))
            {
                AssertShouldNotHaveErrors(validationResult);
            }
            else
            {
                AssertShouldNotCascade(validationResult);
                AssertShouldHaveExpectedErrorCode(validationResult, expectedErrorCode);
            }
        }


        private void AssertShouldNotHaveErrors(ValidationResult validationResult)
        {
            Assert.AreEqual(0, validationResult.Errors.Count, "Validation result should not have errors");
        }

        private void AssertShouldHaveExpectedErrorCode(ValidationResult validationResult, string expectedErrorCode)
        {
            Assert.AreEqual(expectedErrorCode, validationResult.Errors.First().ErrorCode, $"Expected error code {expectedErrorCode}");
        }

        private void AssertShouldNotCascade(ValidationResult validationResult)
        {
            Assert.AreEqual(1, validationResult.Errors.Count, "Validation result should have one error only bc should not cascade");
        }

        private static IEnumerable<TestCaseData> GetStartWordDtoValidatorCases
        {
            get
            {
                yield return new TestCaseData(new StartWordDto(null), Constants.RunRequestValidationErrorMessages.StartWordCannotBeNull);
                yield return new TestCaseData(new StartWordDto(string.Empty), Constants.RunRequestValidationErrorMessages.StartWordCannotBeEmpty);
                yield return new TestCaseData(new StartWordDto("notaniceword"), Constants.RunRequestValidationErrorMessages.StartWordMustHaveExpectedLength);
                yield return new TestCaseData(new StartWordDto("nice"), null);
            }
        }

        private static IEnumerable<TestCaseData> GetWordFileDtoValidatorCases
        {
            get
            {
                yield return new TestCaseData(new WordFileDto(null), true, Constants.RunRequestValidationErrorMessages.WordFilePathCannotBeNull);
                yield return new TestCaseData(new WordFileDto(string.Empty), true, Constants.RunRequestValidationErrorMessages.WordFilePathCannotBeEmpty);
                yield return new TestCaseData(new WordFileDto("some path"), false, Constants.RunRequestValidationErrorMessages.WordFilePathMustExist);
                yield return new TestCaseData(new WordFileDto("some path"), true, null);
            }
        }

        private static IEnumerable<TestCaseData> GetEndWordDtoValidatorCases
        {
            get
            {
                yield return new TestCaseData(new EndWordDto(null, new HashSet<string>{ "endWord"}), Constants.RunRequestValidationErrorMessages.EndWordCannotBeNull);
                yield return new TestCaseData(new EndWordDto(string.Empty, new HashSet<string> { "endWord" }), Constants.RunRequestValidationErrorMessages.EndWordCannotBeEmpty);
                yield return new TestCaseData(new EndWordDto("endWord", new HashSet<string> { "endWord" }), Constants.RunRequestValidationErrorMessages.EndWordMustHaveExpectedLength);
                yield return new TestCaseData(new EndWordDto("word", new HashSet<string> { "word" }), null);
            }
        }

        private static IEnumerable<TestCaseData> GetResultFileDtoValidatorCases
        {
            get
            {
                yield return new TestCaseData(new ResultFileDto(null), Constants.RunRequestValidationErrorMessages.ResultFileNameCannotBeNull);
                yield return new TestCaseData(new ResultFileDto(string.Empty), Constants.RunRequestValidationErrorMessages.ResultFileNameCannotBeEmpty);
                yield return new TestCaseData(new ResultFileDto("resultfile"), null);
            }
        }
    }
}
