# Word ladder exercise 

BluePrism Exercise

## Solution

### Word ladder solving

#### Algorithm
I chose to approach it by using the **BFS** algorithm. This approach uses graphs to find the solution. the first node represents the "root" word, and the following nodes represent words closest (words thar differ by one char) the the previous word (node). 

Each "closest"word found, is then used for the nextsearch iteration.

Because graph search can enter in cycles, it is used a variable to hold visited words.


### Software architecture

#### Application
- The console app serves as the application host;
- The application is defined on **Runner.cs**;
- Strategy pattern was used to isolate word ladder solving logic;
- Implemented Dependency injection with the default dotnet core container;
- Used a service layer to isolate file access, word sanitation and UI responsabilities;
- Used the concept of "validator" to isolate DTOs validation (**FluentValidation** nuget );
- Error messages are provided by a static method that uses a dictionary as PoC to emulates a dynamic data store
- Used logging service for application logging (**Serilog** nuget);
- Interfaces and DTOs are isolated in a different project (**WordLadde.Exercise.Contracts**)

#### Unit Tests
- Tests are implemented using NUnit
- Used **Moq** tocreate mocking objets

#### Benchmark Tests
I found a complete and working algorithm (see references 5). This was used in a benchmark project created to compare with the solutions algorithm. The bechmark project is named **WordLadder.Exercise.BenchmarkTests**. In order to run it go to the project folder and run:

	dotnet run -c Release

Results will appear both on the console and in a results file under the folder **BenchmarkDotNet.Artifacts**.
Used **BenchmarkDotNet** nuget to implement the test.


## References

Used this links to better understand the word ladder problem and possbible approachs to solve it. 

- 1- https://en.wikipedia.org/wiki/Word_ladder
- 2 - https://leetcode.com/problems/word-ladder/
- 3 - https://www.geeksforgeeks.org/breadth-first-search-or-bfs-for-a-graph/
- 4 - https://www.geeksforgeeks.org/word-ladder-length-of-shortest-chain-to-reach-a-target-word/
- 5- https://leetcode.com/problems/word-ladder-ii/discuss/379124/c-creative-idea-to-create-a-graph-and-then-construct-shortest-path-map-practice-in-2019
