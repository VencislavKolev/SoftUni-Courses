function attachEventsListeners() {
    let convertButtons = Array.from(document.querySelectorAll('input[value=Convert]'));

    convertButtons.forEach(btn => {
        btn.addEventListener('click', convertEventHandler);
    })

    function convertEventHandler(e) {
        const convertFrom = e.target.attributes[0].textContent;
        const inputValue = e.target.parentElement.children[1].value;
        let converted = [];

        switch (convertFrom) {
            case 'daysBtn': fromDays(inputValue);
                break;
            case 'hoursBtn': fromDays(inputValue / 24);
                break;
            case 'minutesBtn': fromDays(inputValue / 24 / 60);
                break;
            case 'secondsBtn': fromDays(inputValue / 24 / 60 / 60)
                break;
            default:
                break;
        }

        let inputFields = Array.from(document.querySelectorAll('input[type=text]'));
        inputFields.forEach((e, i) => {
            e.value = converted[i];
        })

        function fromDays(dayValue) {
            converted.push(dayValue);
            converted.push(dayValue * 24);
            converted.push(dayValue * 1440);
            converted.push(dayValue * 86400);
        }
    }
}