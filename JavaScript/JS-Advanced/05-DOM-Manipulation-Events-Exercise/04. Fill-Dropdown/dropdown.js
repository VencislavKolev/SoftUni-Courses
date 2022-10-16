function addItem() {
    let menuSelectElement = document.getElementById('menu');
    let newItemTextElement = document.getElementById('newItemText');
    let newItemValueElement = document.getElementById('newItemValue');

    let optionElement = document.createElement('option');
    optionElement.textContent = newItemTextElement.value;
    optionElement.value = newItemValueElement.value;
    menuSelectElement.appendChild(optionElement);

    newItemTextElement.value = '';
    newItemValueElement.value = '';
}