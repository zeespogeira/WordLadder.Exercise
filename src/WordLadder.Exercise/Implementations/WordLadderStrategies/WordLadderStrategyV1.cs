using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordLadder.Exercise.Contracts.Interfaces;
using WordLadder.Exercise.Contracts.ResponseObjs;

namespace WordLadder.Exercise.Implementations.WordLadderStrategies
{
    /*
     * Algorithm from https://leetcode.com/problems/word-ladder-ii/discuss/379124/c-creative-idea-to-create-a-graph-and-then-construct-shortest-path-map-practice-in-2019
     */
    public class WordLadderStrategyV1 : IWordLadderStrategy
    {
        public WordLadderStrategyResponse FindShortestLadders(string startWord, string endWord, HashSet<string> words)
        {
            var graph = new Dictionary<string, HashSet<string>>();

            PreprocessGraph(startWord, graph);

            foreach (var word in words)
            {
                PreprocessGraph(word, graph);
            }

            //Queue For BFS
            var queue = new Queue<string>();

            //Dictionary to store shortest paths to a word
            var shortestPaths = new Dictionary<string, List<List<string>>>();

            queue.Enqueue(startWord);
            // do not confuse () with {} - fix compiler error
            shortestPaths[startWord] = new List<List<string>>() { new List<string>() { startWord } };

            var visited = new HashSet<string>();

            while (queue.Count > 0)
            {
                var visit = queue.Dequeue();

                //we can terminate loop once we reached the endWord as all paths leads here already visited in previous level 
                if (visit.Equals(endWord))
                {
                    return new WordLadderStrategyResponse(shortestPaths[endWord].FirstOrDefault());
                }

                if (visited.Contains(visit))
                    continue;

                visited.Add(visit);

                //Transform word to intermediate words and find matches
                // case study: var source = "good";  
                // go over all keys related to visit = "good" for example,
                // keys: "*ood","g*od","go*d","goo*"
                for (int i = 0; i < visit.Length; i++)
                {
                    var sb = new StringBuilder(visit);

                    sb[i] = '*';

                    var key = sb.ToString();

                    if (!graph.ContainsKey(key))
                    {
                        continue;
                    }

                    //brute force all adjacent words
                    foreach (var neighbor in graph[key])
                    {
                        if (visited.Contains(neighbor))
                        {
                            continue;
                        }

                        //fetch all paths leads current word to generate paths to adjacent/child node 
                        foreach (var path in shortestPaths[visit])
                        {
                            var newPath = new List<string>(path);

                            newPath.Add(neighbor); // path increments one, before it is saved in shortestPaths

                            if (!shortestPaths.ContainsKey(neighbor))
                            {
                                shortestPaths[neighbor] = new List<List<string>>() { newPath };
                            }        // reasoning ? 
                            else if (shortestPaths[neighbor][0].Count >= newPath.Count) // // we are interested in shortest paths only
                            {
                                shortestPaths[neighbor].Add(newPath);
                            }
                        }

                        queue.Enqueue(neighbor);
                    }
                }
            }

            return new WordLadderStrategyResponse(new List<string>());
        }

        private void PreprocessGraph(string word, Dictionary<string, HashSet<string>> graph)
        {
            //For example word hit can be written as *it,h*t,hi*. 
            //This method genereates a map from each intermediate word to possible words from our wordlist
            for (int i = 0; i < word.Length; i++)
            {
                var sb = new StringBuilder(word);
                sb[i] = '*';

                var key = sb.ToString();

                if (graph.ContainsKey(key))
                {
                    graph[key].Add(word);
                }
                else
                {
                    var set = new HashSet<string>();
                    set.Add(word);
                    graph[key] = set;
                }
            }
        }
    }
}
