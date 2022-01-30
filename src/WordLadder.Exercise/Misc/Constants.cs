namespace WordLadder.Exercise.Misc
{
    public class Constants
    {
        public const int ExpectedWordSize = 4;

        public class RunRequestValidationErrorMessages
        {
            public const string WordFilePathCannotBeNull = "WordFilePathCannotBeNull";
            public const string WordFilePathCannotBeEmpty = "WordFilePathCannotBeEmpty";
            public const string WordFilePathMustExist = "WordFilePathMustExist";
            public const string StartWordCannotBeNull = "StatWordCannotBeNull";
            public const string StartWordCannotBeEmpty = "StatWordCannotBeEmpty";
            public const string StartWordMustHaveExpectedLength = "StartWordMustHaveExpectedLength";
            public const string EndWordCannotBeNull = "EndWordCannotBeNull";
            public const string EndWordCannotBeEmpty = "EndWordCannotBeEmpty";
            public const string EndWordMustHaveExpectedLength = "EndWordMustHaveExpectedLength";
            public const string ResultFileNameCannotBeNull = "ResultFileNameCannotBeNull";
            public const string ResultFileNameCannotBeEmpty = "ResultFileNameCannotBeEmpty";
        }
    }
}
