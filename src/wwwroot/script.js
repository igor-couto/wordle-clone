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
    status: GameStatus.InProgress
}

if(!window.localStorage.getItem('game'))
{
    window.localStorage.setItem('game', JSON.stringify(game));
}

document.addEventListener('keydown', handleKeyboardInput);
document.querySelectorAll('.game-keyboard-button').forEach(button => {
    button.addEventListener('click', handleOnScreenKeyboard);
});

async function submitGuess(word) {
    if (word.length !== 5) {
        setMessage("Word must be 5 letters!");
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

        if (data.isCorrect) {
            game.status = GameStatus.Won;
            setMessage("Congratulations, you won!");
        } else {
            currentRow = getCurrentRow();
            currentTile = getNextEmptyTile(currentRow);
        }
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
                break;
            case LetterPlacement.Incorrect: 
                tileClass = 'letter-elsewhere';
                break;
            case LetterPlacement.NotPresent:
                tileClass = 'letter-absent';
                break;
        }
        tiles[index].classList.add(tileClass);
        tiles[index].textContent = letter.character.toUpperCase();
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