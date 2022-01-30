using System.Collections.Generic;
using System.Linq;
using WordLadder.Exercise.Contracts.Interfaces;
using WordLadder.Exercise.Contracts.ResponseObjs;

namespace WordLadder.Exercise.Implementations.WordLadderStrategies
{
    public class WordLadderStrategyV2 : IWordLadderStrategy
    {
        public WordLadderStrategyResponse FindShortestLadders(string startWord, string endWord, HashSet<string> words)
        {
            //ladders will contain lists (value) with the possible paths to get to the a word (key)
            var ladders = new Dictionary<string, List<List<string>>>();

            AddFirst(ladders, startWord);

            var queue = new Queue<string>();

            queue.Enqueue(startWord);

            while (queue.Count > 0)
            {
                //stores a set of strings that are close to top string on the queue (object of search)
                var visitedWords = new HashSet<string>();

                //for each word in queue, try to find its closest words in word list (closest = differs only by on char)
                for (var i = 0; i < queue.Count; i++)
                {
                    var rootOfSearch = queue.Peek();

                    var rootOfSearchChars = rootOfSearch.ToCharArray();

                    //this loop intends to find 
                    for (var j = 0; j < rootOfSearchChars.Length; j++)
                    {
                        var auxiliarChar = rootOfSearchChars[j];

                        //brute force new words by changing only one char
                        for (var c = 'a'; c <= 'z'; c++)
                        {
                            //guard
                            if (rootOfSearchChars[j] == c)
                            {
                                continue;
                            }

                            //change the char
                            rootOfSearchChars[j] = c;

                            //and creates a new word to be tested
                            var testWord = new string(rootOfSearchChars);

                            //if not exists in words list then should not be considered
                            if (!words.Contains(testWord))
                            {
                                continue;
                            }

                            var newList = new List<List<string>>();

                            //kind of concatenate the test word to list strings
                            foreach (var ladder in ladders[rootOfSearch])
                            {
                                var auxiliarList = new List<string>(ladder) { testWord };
                                newList.Add(auxiliarList);
                            }

                            if (!ladders.ContainsKey(testWord))
                            {
                                ladders[testWord] = new List<List<string>>();
                                
                            }

                            ladders[testWord].AddRange(newList);

                            //add to visited words, to later remove from words list
                            visitedWords.Add(testWord);
                        }

                        //re set the word "searched" 
                        rootOfSearchChars[j] = auxiliarChar;
                    }

                    queue.Dequeue();
                }

                if (ladders.ContainsKey(endWord))
                {
                    break;
                }

                foreach (string s in visitedWords)
                {
                    //remove visited words from words list(avoid cycle)
                    words.Remove(s);

                    //and enqueue them to be object of new search (to find close words)
                    queue.Enqueue(s);
                }
            }

            if (!ladders.ContainsKey(endWord))
            {
                return new WordLadderStrategyResponse(new List<string>());
            }

            var shortest = ladders[endWord].OrderBy(x => x.Count).First();

            return new WordLadderStrategyResponse(shortest);
        }


        private void AddFirst(IDictionary<string, List<List<string>>> ladders, string word)
        {
            var list = new List<List<string>>();

            var subList = new List<string> { word };

            list.Add(subList);

            ladders[word] = new List<List<string>>(list);
        }

    }
}
