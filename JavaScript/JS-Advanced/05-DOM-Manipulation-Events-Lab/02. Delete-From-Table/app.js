function deleteByEmail() {
    let emailInputElement = document.querySelector('input[name=email]');
    let emailTdElements = Array.from(document.querySelectorAll('tr td:nth-child(even)'));
    let resultElement = document.getElementById('result');

    let match = emailTdElements.find(x => x.textContent === emailInputElement.value);
    if (match) {
        match.parentElement.remove();
        resultElement.textContent = 'Deleted.'
    } else {
        resultElement.textContent = 'Not found.'
    }
}