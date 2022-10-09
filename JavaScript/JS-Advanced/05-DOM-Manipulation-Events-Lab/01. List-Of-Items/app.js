function addItem() {
    let inputElement = document.getElementById('newItemText');
    let itemsList = document.querySelector('ul');
    let newItem = document.createElement('li');
    newItem.textContent = inputElement.value;
    itemsList.appendChild(newItem);
}