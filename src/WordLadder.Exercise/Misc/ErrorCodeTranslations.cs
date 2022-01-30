using System.Collections.Generic;

namespace WordLadder.Exercise.Misc
{
    public class ErrorCodeTranslations
    {
        //for the sake of simplicity this is a static dictionary, on real environments it's source could be a DB, file...
        private static Dictionary<string, string> _translations = new Dictionary<string, string>()
        {
            { 
                Constants.RunRequestValidationErrorMessages.WordFilePathCannotBeNull, 
                "Word File Path Cannot Be Null"
            },
            {
                Constants.RunRequestValidationErrorMessages.WordFilePathCannotBeEmpty, 
                "Word File Path Cannot Be Empty"
            },
            {
                Constants.RunRequestValidationErrorMessages.WordFilePathMustExist,
                "Word File Must Exist Does Not Exist In Path"
            },
            {
                Constants.RunRequestValidationErrorMessages.StartWordCannotBeEmpty, 
                "Start Word Cannot Be Empty"
            },
            {
                Constants.RunRequestValidationErrorMessages.StartWordCannotBeNull, 
                "Start Word Cannot Be Null"
            },
            {
                Constants.RunRequestValidationErrorMessages.StartWordMustHaveExpectedLength,
                $"Start Word Must Have Expected Length ({Constants.ExpectedWordSize} chars)"
            },
            {
                Constants.RunRequestValidationErrorMessages.EndWordCannotBeNull, 
                "End Word Cannot Be Null"
            },
            {
                Constants.RunRequestValidationErrorMessages.EndWordCannotBeEmpty, 
                "End Word Cannot Be Empty"
            },
            {
                Constants.RunRequestValidationErrorMessages.EndWordMustHaveExpectedLength,
                "End Word Must Have Expected Length ({Constants.ExpectedWordSize} chars)"
            },
            {
                Constants.RunRequestValidationErrorMessages.ResultFileNameCannotBeNull, 
                "Result File Name Cannot BeNull"
            },
            {
                Constants.RunRequestValidationErrorMessages.ResultFileNameCannotBeEmpty,
                "Result File Name Cannot Be Empty"
            }
        };

        public static string GetTranslation(string errorCode)
        {
            return _translations.TryGetValue(errorCode, out string translation) ? translation : errorCode;
        }
    }
}
