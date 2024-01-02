# Wordle Clone in C#
[![Build](https://github.com/igor-couto/wordle-clone/actions/workflows/build.yml/badge.svg)](https://github.com/igor-couto/wordle-clone/actions/workflows/build.yml)

## Overview
This project is a clone of the popular word-guessing game Wordle. It's a simple, interactive web-based game where players attempt to guess a five-letter word within a set number of tries. Each guess provides feedback on the letters in the word, indicating whether they are in the correct position, present in the word but in a different position, or not in the word at all.

![](https://github.com/igor-couto/images/blob/main/wordle-clone/preview.png)

## Setup and Installation

### Prerequisites
- A modern web browser that supports HTML5, CSS3, and JavaScript ES6.
- .NET 8 Runtime and SDK

### Running the Game

1. Use git clone or download the ZIP file of this repository.

2. Navigate to the .NET project directory and start the backend server using `dotnet run`.

3. Open the folder where the project files are located and open `index.html`

## How to Play
1. Load the game in your web browser. You will see a grid of empty tiles representing the guesses you can make.
2. Make a Guess: Type a 5-letter word using either your physical keyboard or the on-screen keyboard and press _Enter_.
3. Check Feedback. Each tile will change color based on your guess:
- **Green:** Letter is in the word and in the correct position.
- **Yellow:** Letter is in the word but in a different position.
- **Gray:** Letter is not in the word.
4. Continue making guesses based on the feedback. You have limited attempts to guess the correct word.
5. The game ends when you correctly guess the word or run out of attempts.

## Technologies Used

### Fontend
- HTML5
- CSS3
- JavaScript (ES6)

### Backend
- C#
- .NET 8 
- Swagger

### Why this stack?
I consciously chose to use vanilla HTML, CSS, and JavaScript for the frontend. This decision was guided by a preference for simplicity and efficiency. In an era where JavaScript frameworks are increasingly ubiquitous, there's a tendency to default to using these tools for even the most straightforward tasks. I believe that not every project requires such complexity. By sticking to the fundamentals of web development, this project maintains a lean and straightforward codebase, free from unnecessary dependencies and the overhead that comes with heavier frameworks. This approach allows for easier understanding, modification, and maintenance of the code, making it a practical choice for a game like Wordle.


## Benchmarking
In this project, I'm conducting performance benchmarks to compare two distinct approaches for searching strings within a set of words: Trie Tree vs LINQ Contains Method. The motivation behind this comparison is to identify the most efficient method in terms of execution speed and resource usage.

### Running the Benchmark
To run these benchmarks, simply execute the `run-benchmark.sh` script in the root of the repository. This script will automatically set up the environment and run the benchmarks, making it easy to reproduce the tests.

### Benchmark Results
You can find the detailed results of the benchmarking [here](https://github.com/igor-couto/wordle-clone/blob/main/test/benchmark/BenchmarkDotNet.Artifacts/results/WordleClone.Benchmark.FindWordsBenchmarks-report-default.md)

## Contributing
Contributions to the project are welcome! To contribute, simply fork the repository and create your feature branch. Once you've made your changes, submit them via a pull request for review.

## Author
* **Igor Couto** - [igor.fcouto@gmail.com](mailto:igor.fcouto@gmail.com)