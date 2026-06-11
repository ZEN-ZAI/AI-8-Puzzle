# AI 8-Puzzle Solver

Console 8-puzzle solver in C# — greedy best-first search guided by a Manhattan-distance heuristic.

## How it works

- Each 3×3 board state is keyed as a 9-digit string and tracked in a visited-state hash table
- The frontier is a priority queue ordered by the sum of Manhattan (taxicab) distances of tiles 1–8 from their goal positions
- Each expanded state stores a link to its parent, so the solution path is reconstructed by walking back from the goal
- Prints every expanded state with its priority, then the final path

## Run

Open `8-Puzzle.sln` in Visual Studio and run — it's a .NET Framework console app; NuGet restores the priority-queue dependency on build.

Edit the `start` / `goal` arrays in `Program.cs` to try other boards.

---

*University AI coursework (2019), kept as-is.*
