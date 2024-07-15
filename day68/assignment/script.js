
document.addEventListener('keydown', (e) => {
    const key = e.key;
    const keyElement = document.getElementById(key);
    if (keyElement) {
        keyElement.classList.toggle('bg-gray-400');
    }
});

document.addEventListener('keyup', (e) => {
    const key = e.key;
    const keyElement = document.getElementById(key);
    if (keyElement) {
        keyElement.classList.toggle('bg-gray-400');
    }
});