function extractText() {
    let items = document.getElementById('items');
    let children = items.innerText;

    let textArea = document.getElementById('result');
    textArea.textContent = children;
}