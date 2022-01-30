using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WordLadder.Exercise.Contracts.DTOs;
using WordLadder.Exercise.Contracts.Interfaces;
using WordLadder.Exercise.Contracts.ResponseObjs;

namespace WordLadder.Exercise.Implementations.Implementations.Services
{
    public class UIService : IUIService
    {
        private readonly IValidator<WordFileDto> _wordFileValidator;
        private readonly IValidator<StartWordDto> _startWordValidator;
        private readonly IValidator<EndWordDto> _endWordValidator;
        private readonly IValidator<ResultFileDto> _resultFileValidator;
        private ResultFileDto _resultFile;
        private WordFileDto _wordFile;
        private EndWordDto _endWord;
        private StartWordDto _startWord;

        public UIService(IValidator<WordFileDto> wordFileValidator, 
            IValidator<StartWordDto> startWordValidator,
            IValidator<EndWordDto> endWordValidator,
            IValidator<ResultFileDto> resultFileValidator)
        {
            _wordFileValidator = wordFileValidator;
            _startWordValidator = startWordValidator;
            _endWordValidator = endWordValidator;
            _resultFileValidator = resultFileValidator;
        }

        public void DisplayIntro()
        {
            Console.WriteLine("/**************************************/");
            Console.WriteLine("/*********** WORD LADDER **************/");
            Console.WriteLine("/*********** ¯\\_(ツ)_/¯ **************/");
            Console.WriteLine("/**************************************/");
            Console.WriteLine();
            Console.WriteLine();
        }

        public string AskWordFilePath()
        {
            bool hasErrorsFlag;

            do
            {
                Console.WriteLine();
                Console.WriteLine("What is the path to the words file?");
                Console.Write("Answer: ");

                _wordFile = new WordFileDto(Console.ReadLine());

                var validationResult = _wordFileValidator.Validate(_wordFile);

                hasErrorsFlag = HasErrors(validationResult);

                if(hasErrorsFlag)
                {
                    PrintErrors(validationResult);
                }

            } while (hasErrorsFlag);

            return _wordFile.Path;
        }

        public string AskStartWord()
        {
            bool hasErrorsFlag;

            do
            {
                Console.WriteLine();
                Console.WriteLine("What is the start word?");
                Console.Write("Answer: ");

                _startWord = new StartWordDto(Console.ReadLine());
                
                var validationResult = _startWordValidator.Validate(_startWord);

                hasErrorsFlag = HasErrors(validationResult);
                
                if (hasErrorsFlag)
                {
                    PrintErrors(validationResult);
                }

            } while (hasErrorsFlag);

            return _startWord.StartWord;
        }

        public string AskEndWord(HashSet<string> words)
        {
            bool hasErrorsFlag;

            do
            {
                Console.WriteLine();
                Console.WriteLine("What is the end word?");
                Console.Write("Answer: ");

                _endWord = new EndWordDto(Console.ReadLine(), words);
                
                var validationResult = _endWordValidator.Validate(_endWord);

                hasErrorsFlag = HasErrors(validationResult);

                if (hasErrorsFlag)
                {
                    PrintErrors(validationResult);
                }

            } while (hasErrorsFlag);

            return _endWord.EndWord;
        }

        public string AskResultFileName()
        {
            bool hasErrorsFlag;

            do
            {
                Console.WriteLine();
                Console.WriteLine("What is the name of the result file?");
                Console.Write("Answer: ");
                
                _resultFile = new ResultFileDto(Console.ReadLine());

                var validationResult = _resultFileValidator.Validate(_resultFile);

                hasErrorsFlag = HasErrors(validationResult);

                if (hasErrorsFlag)
                {
                    PrintErrors(validationResult);
                }

            } while (hasErrorsFlag);

            return _resultFile.FileName;
        }

        public void Summary()
        {
            Console.WriteLine();
            Console.WriteLine("INPUTS");
            Console.WriteLine($"Word File: {_wordFile.Path}");
            Console.WriteLine($"Start Word: {_startWord.StartWord}");
            Console.WriteLine($"End Word: {_endWord.EndWord}");
            Console.WriteLine($"Result File: {_resultFile.FileName}");
            Console.WriteLine();
        }

        public void DisplaySuccessRunResult(WordLadderStrategyResponse response, string resultFileName)
        {
            Console.WriteLine();
            Console.WriteLine("WordLadder Run Result:");
            Console.WriteLine($"Number of Steps: {response.NumberOfSteps}");
            Console.WriteLine($"Number of Steps: {response.Ladder.Aggregate((a, b)=> $"{a} -> {b}")}");
        }

        public void DisplayErrorRunResult()
        {
            Console.WriteLine();
            Console.WriteLine("The wordladder executed with errors :\\");
            Console.WriteLine("Please check log file");
        }

        private bool HasErrors(ValidationResult validationResult)
        {
            return validationResult != null && validationResult.Errors.Any();
        }

        private void PrintErrors(ValidationResult validationResult)
        {
            foreach (var validationResultError in validationResult.Errors)
            {
                Console.WriteLine($"bahh...{ErrorCodeTranslations.GetTranslation(validationResultError.ErrorCode)}");
            }
        }
    }
}
