function validate() {
    let inputElement = document.getElementById('email');
    inputElement.addEventListener('change', onChange);

    function onChange(e) {
        if (!isEmail(e.currentTarget.value)) {
            e.currentTarget.className = 'error';
        } else {
            e.currentTarget.className = '';
        }
    }

    function isEmail(value) {
        let pattern = /^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/;
        return pattern.test(value);
    }
}