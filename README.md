# Maze Generator

<img width="1280" alt="maze_gen_1" src="https://github.com/aruiz-ba/MazeGenerator/assets/46310231/124bfc0d-668c-4776-aec0-b98f2044bffa">

## Objectives

The objective of this project is to create an Android application using Unity that is capable of generating mazes. We will be using Randomized depth-first search, which is an algorithm derived from backtracking.

## Backtracking

![backtrack_maze](https://github.com/aruiz-ba/MazeGenerator/assets/46310231/da773533-adfb-4ba2-be14-7763a0e244f7)

![backtrack_sudoku](https://github.com/aruiz-ba/MazeGenerator/assets/46310231/4cbf0d52-4fa6-4186-bc99-5787be710093)


Backtracking is a type of algorithm that allows for finding solutions to some computational problems, in particular, constraint satisfaction problems, that incrementally builds candidates to the solutions and abandons a candidate ("backtracks") as soon as it determines that the candidate cannot be completed to a valid solution.

This algorithm is used to solve problems such as mazes and Sudokus. In summary, using recursion, the algorithm takes out all possibilities while discarding invalid ones until it finds the result.

## Randomized Depth-First Search

![backtrack_maze_creation](https://github.com/aruiz-ba/MazeGenerator/assets/46310231/def0c9b8-8dd9-4c35-95e8-5c81c6866083)

This approach is one of the simplest ways to generate a maze using a computer. Let's consider that the space for the maze is a large grid of cells (like a large chessboard) and that each cell starts with four walls. Starting from a random cell, the computer selects a random neighboring cell that has not been visited yet. The computer removes the wall between the two cells, marks the new cell as visited, and adds it to the stack for backtracking. The computer continues this process, and a cell that has no unvisited neighbors is considered a dead end. When it finds itself in a dead end, it backtracks along the path until it reaches a cell with an unvisited neighbor, and it continues the path generation by visiting this new unvisited cell (creating a new junction). This process continues until all cells have been visited, making the computer backtrack all the way to the initial cell. We can be sure that all cells have been visited.

## Result

<img width="1279" alt="maze_gen_3" src="https://github.com/aruiz-ba/MazeGenerator/assets/46310231/ec457167-3853-4d99-9705-28f724c55352">

<img width="1276" alt="maze_gen_2" src="https://github.com/aruiz-ba/MazeGenerator/assets/46310231/283c4b31-e905-42b6-b93d-0c395ac91dcd">
