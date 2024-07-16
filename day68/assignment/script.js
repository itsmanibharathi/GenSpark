let currentRow = 1;
let currentCol = 1;
const word = "apple";
let guessWord = "";

document.addEventListener("keydown", (e) => {
    highlightKey(e.key);
    runAction(e.key);

});

function runAction(key) {
    if (guessWord.length > 0) {
        window.addEventListener("beforeunload", handleBeforeUnload);
    } else {
        window.removeEventListener("beforeunload", handleBeforeUnload);
    }
    if (key === "Enter") {
        if (currentCol == 6) {
            checkGuess();
            currentRow++;
            currentCol = 1;
            guessWord = '';
            if (currentRow > 6) {
                alert("Game Over! You've exhausted all your chances.");
                window.removeEventListener("beforeunload", handleBeforeUnload);
                location.reload();
            }
        }
    } else if (key === "Backspace") {
        if (currentCol > 1) {
            currentCol--;
            updateBoard('');
            guessWord = guessWord.slice(0, -1);
        }
    } else if (/^[a-z]$/.test(key)) {
        if (currentCol < 6) {
            console.log(currentRow, currentCol);
            updateBoard(key);
            guessWord += key;
            currentCol++;
        }
    }
}

function highlightKey(key) {
    const keyDiv = document.getElementById(key.toLowerCase());
    if (keyDiv) {
        keyDiv.classList.add("bg-gray-400");
        setTimeout(() => {
            keyDiv.classList.remove("bg-gray-400");
        }, 300);
    }
}

function updateBoard(data) {
    document.getElementById(`row${currentRow}col${currentCol}`).innerHTML = data;
}

function handleBeforeUnload(event) {
    event.preventDefault();
    event.returnValue = '';
}

function checkGuess() {
    for (let col = 1; col < 6; col++) {
        const letter = document.getElementById(`row${currentRow}col${col}`).innerHTML;
        if (word[col - 1] === letter) {
            document.getElementById(`row${currentRow}col${col}`).classList = "col correct animate-flip";
        } else if (word.includes(letter)) {
            document.getElementById(`row${currentRow}col${col}`).classList = "col present animate-flip";
        }
    }
    if (guessWord == word) {
        alert("Congratulations! You've guessed the word correctly!");
        window.removeEventListener("beforeunload", handleBeforeUnload);
        location.reload();
    }
}
