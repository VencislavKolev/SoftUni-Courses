function generateReport() {
    let checkboxes = document.querySelectorAll('input[type=checkbox]');
    let rows = document.querySelectorAll("tbody tr");
    let result = [];

    for (let i = 0; i < rows.length; i++) {
        let info = {};
        for (let j = 0; j < checkboxes.length; j++) {
            if (checkboxes[j].checked) {
                let columnName = checkboxes[j].name;
                let value = rows[i].textContent
                    .split("\n")
                    .map(x => x.trim())
                    .filter(x => x !== "")[j];
                info[columnName] = value;
            }
        }
        result.push(info);
    }
    let outputElement = document.querySelector("#output");
    outputElement.value = JSON.stringify(result, null, 2);
}