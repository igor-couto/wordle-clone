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
  
## Contributing
Contributions to the project are welcome! To contribute, simply fork the repository and create your feature branch. Once you've made your changes, submit them via a pull request for review.

## Author
* **Igor Couto** - [igor.fcouto@gmail.com](mailto:igor.fcouto@gmail.com)
