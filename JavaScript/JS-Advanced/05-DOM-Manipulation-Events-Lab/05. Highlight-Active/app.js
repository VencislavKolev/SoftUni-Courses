function focused() {
    let inputElements = Array.from(document.getElementsByTagName('input'));
    inputElements.forEach(input => {
        input.addEventListener('focus', isFocused);
        input.addEventListener('blur', isBlurred);
    })

    function isFocused(e) {
        console.log(e.currentTarget);
        e.currentTarget.parentElement.classList.add('focused');
    }
    function isBlurred(e) {
        e.currentTarget.parentElement.classList.remove('focused');
    }
}