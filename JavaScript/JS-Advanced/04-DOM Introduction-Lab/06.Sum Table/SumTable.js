function sumTable() {
    // Option 1
    // let rows = document.querySelectorAll('tr td');
    // let rowsArr = Array.from(rows)
    //     .filter((x, index) => index % 2 != 0)
    //     .slice(0, 3)
    //     .map((x) => Number(x.textContent));

    //Option 2
    let rows = document.querySelectorAll('tr td:nth-child(2n)');
    let rowsArr = Array.from(rows);
    // .slice(0, 3);
    // .map((x) => Number(x.textContent));
    rowsArr.pop();

    let sum = rowsArr.reduce((acc, cur) => {
        let current = Number(cur.textContent) || 0
        return acc + current;
    }, 0);

    let sumElement = document.getElementById('sum');
    sumElement.textContent = sum;
}