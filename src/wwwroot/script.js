const GameStatus = {
    InProgress: 0,
    Won: 1,
    Lost: 2
};

const LetterPlacement = {
    Correct: 0,
    Incorrect: 1,
    NotPresent: 2
};

let currentRow = getCurrentRow();
let currentTile = getNextEmptyTile(currentRow);

let game = {
    sessionId: generateUuid(),
    status: GameStatus.InProgress,
    boardState: ["", "", "", "", "", ""]
}

if (!window.localStorage.getItem('game'))
{
    window.localStorage.setItem('game', JSON.stringify(game));
}
else
{
    game = JSON.parse(window.localStorage.getItem('game'));
    loadGameBoard();
}


document.addEventListener('keydown', handleKeyboardInput);
document.querySelectorAll('.game-keyboard-button').forEach(button => {
    button.addEventListener('click', handleOnScreenKeyboard);
});

function loadGameBoard() {
    const rows = document.querySelectorAll('.Row');

    game.boardState.forEach((guess, index) => {
        if (guess !== "" && rows[index]) {
            const tiles = rows[index].querySelectorAll('.Row-letter');
            guess.split('').forEach((char, charIndex) => {
                if (tiles[charIndex]) {
                    tiles[charIndex].textContent = char.toUpperCase();
                }
            });
            if (game.status === GameStatus.Won) {
                // UI update logic for a game that's already won
            }
        }
    });

    currentRow = getCurrentRow();
    currentTile = getNextEmptyTile(currentRow);
}

async function submitGuess(word) {
    if (word.length !== 5) {
        setMessage("Word must be 5 letters!");
        return;
    }

    if (game.boardState.includes(word)) {
        setMessage("You have already guessed this word.");
        return;
    }

    try {
        const response = await fetch(`https://localhost:53120/guess?word=${word}`);

        if (!response.ok) {
            if(response.status == 404)
            {
                const data = await response.json();
                setMessage(data.message);
                return;
            }
            else
            {
                throw new Error('Network response was not ok');
            }
        }

        const data = await response.json();
        updateTiles(data);

        game.boardState[currentRow.rowIndex] = word;
        window.localStorage.setItem('game', JSON.stringify(game));

        if (data.isCorrect) {
            game.status = GameStatus.Won;
            game.boardState[currentRow.rowIndex] = word;
            setMessage("Congratulations, you won!");
        } else {
            currentRow = getCurrentRow();
            currentTile = getNextEmptyTile(currentRow);
            game.boardState[currentRow.rowIndex -1] = word;
        }

        window.localStorage.setItem('game', JSON.stringify(game));

    } catch (error) {
        console.error('Fetch error:', error);
        setMessage(error);
    }
}

function updateTiles(data) {
    const tiles = currentRow.querySelectorAll('.row-letter');

    data.letters.forEach((letter, index) => {
        let tileClass;
        switch (letter.letterPlacement) {
            case LetterPlacement.Correct: 
                tileClass = 'letter-correct';
                updateKeyboardButtonStatus(letter.character, tileClass);
                break;
            case LetterPlacement.Incorrect: 
                tileClass = 'letter-elsewhere';
                updateKeyboardButtonStatus(letter.character, tileClass);
                break;
            case LetterPlacement.NotPresent:
                tileClass = 'letter-not-present';
                updateKeyboardButtonStatus(letter.character, tileClass);
                break;
        }
        tiles[index].classList.add(tileClass);
        tiles[index].textContent = letter.character.toUpperCase();
    });
}

function updateKeyboardButtonStatus(letter, status) {
    const buttons = document.querySelectorAll('.game-keyboard-button');
    buttons.forEach(button => {
        if (button.textContent.toUpperCase() === letter.toUpperCase()) {
            
            if(!button.classList.contains('letter-correct'))
            {
                button.classList.remove('letter-elsewhere', 'letter-not-present');
                button.classList.add(status);
            }
        }
    });
}

function handleOnScreenKeyboard(event) {
    if (game.status !== GameStatus.InProgress) return;

    const button = event.target;
    const letter = button.textContent;

    if(letter === 'Enter')
    {
        submitGuess(getCurrentGuess());
        return;
    }

    if(letter === '⌫')
    {
        deleteLastLetter();
        return;
    }

    if (currentTile && letter.length === 1) {
        currentTile.textContent = letter.toUpperCase();
        currentTile = getNextEmptyTile(currentRow);
    }
}

function handleKeyboardInput(event) {
    if (game.status !== GameStatus.InProgress) return;

    const key = event.key;

    if (currentTile && key.match(/^[a-zA-Z]$/)) {
        currentTile.textContent = key.toUpperCase();
        currentTile = getNextEmptyTile(currentRow);
    } else if (key === 'Enter') {
        submitGuess(getCurrentGuess());
    } else if (key === 'Backspace') {
        deleteLastLetter();
    }
}

function deleteLastLetter() {
    if (!currentRow || game.status !== GameStatus.InProgress) return '';

    const tiles = Array.from(currentRow.querySelectorAll('.row-letter'));
    for (let i = tiles.length - 1; i >= 0; i--) {
        if (tiles[i].textContent.trim()) {
            tiles[i].textContent = '';
            currentTile = tiles[i];
            break;
        }
    }
}

function getCurrentGuess() {
    if (!currentRow || game.status === GameStatus.Won) return '';

    const tiles = currentRow.querySelectorAll('.row-letter');
    return Array.from(tiles).map(tile => tile.textContent.trim()).join('');
}

function getCurrentRow() {
    const rows = document.querySelectorAll('.row');
    for (let i = 0; i < rows.length; i++) {
        const tiles = rows[i].querySelectorAll('.row-letter');
        const isNotFull = Array.from(tiles).some(tile => !tile.textContent.trim());
        if (isNotFull) {
            return rows[i];
        }
    }
    return null; // No more rows available or all rows are filled
}

function getNextEmptyTile(row) {
    const tiles = row.querySelectorAll('.row-letter');
    for (let tile of tiles) {
        if (!tile.textContent.trim()) {
            return tile;
        }
    }
    return null; // No empty tile in this row
}

function setMessage(message) {
    document.getElementById('message').textContent = message;
}

function generateUuid() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    );
}