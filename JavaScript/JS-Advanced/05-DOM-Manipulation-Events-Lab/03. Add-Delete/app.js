function addItem() {
    let inputElement = document.getElementById('newItemText');
    let items = document.getElementById('items');

    let liItem = document.createElement('li');
    liItem.textContent = inputElement.value;
    inputElement.value = '';

    let deleteElement = document.createElement('a');
    deleteElement.setAttribute('href', '#');
    deleteElement.textContent = '[Delete]';

    const deleteElementEventHandler = function (e) {
        e.currentTarget.parentElement.remove();
    }
    deleteElement.addEventListener('click', deleteElementEventHandler);

    liItem.appendChild(deleteElement);
    items.appendChild(liItem);
}