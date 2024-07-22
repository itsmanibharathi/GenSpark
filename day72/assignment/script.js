const letters = ["T", "B", "O", "I", "L", "G", "S"];
const predefinedWords = ["BOIL", "SOIL", "TOIL", "GILL"];
let currentWord = "";
let foundWords = [];

const letterContainer = document.getElementById("letter-container");
const wordsDiv = document.getElementById("words");
const wordCountSpan = document.getElementById("word_count");
const scoreSpan = document.getElementById("score");
const rankSpan = document.getElementById("rank");
const deleteBtn = document.getElementById("delete-btn");
const refreshBtn = document.getElementById("refresh-btn");
const enterBtn = document.getElementById("enter-btn");

function shuffleLetters() {
    const shuffledLetters = letters.slice(1).sort(() => Math.random() - 0.5);
    letterContainer.innerHTML = "";
    letterContainer.appendChild(createLitterDiv(letters[0], true));
    shuffledLetters.forEach((letter, index) => {
        letterContainer.appendChild(createLitterDiv(letter));
    });

}

function createLitterDiv(letter, center = false) {
    const letterDiv = document.createElement("div");
    letterDiv.className = "hex";
    letterDiv.textContent = letter;
    letterDiv.onclick = () => addLetterToWord(letter);
    if (center) {
        letterDiv.className += " center";
    }
    return letterDiv;
}

function addLetterToWord(letter) {
    console.log(letter);
    document.getElementById("word-input").value += letter;
    currentWord += letter;
}

deleteBtn.addEventListener("click", () => {
    currentWord = currentWord.slice(0, -1);
    document.getElementById("word-input").value = currentWord;
});

refreshBtn.addEventListener("click", shuffleLetters);

enterBtn.addEventListener("click", validateWord);

function validateWord() {
    if (predefinedWords.includes(currentWord) && !foundWords.includes(currentWord)) {
        foundWords.push(currentWord);
        scoreSpan.textContent = foundWords.length * 4;
        rankSpan.textContent = getRank(foundWords.length);
        wordCountSpan.textContent = foundWords.length;
        wordsDiv.innerHTML += `<div>${currentWord}</div>`;
    } else {
        alert("Invalid word");
    }
    currentWord = "";
    document.getElementById("word-input").value = "";
}

function getRank(wordCount) {
    if (wordCount >= 10) return "Expert";
    if (wordCount >= 5) return "Intermediate";
    return "Beginner";
}

document.addEventListener("keydown", (e) => {
    if (e.key === "Backspace") {
        deleteBtn.click();
    } else if (e.key === "Enter") {
        enterBtn.click();
    } else {
        const letter = e.key.toUpperCase();
        if (letters.includes(letter)) {
            addLetterToWord(letter);
        }
    }
});

shuffleLetters();
