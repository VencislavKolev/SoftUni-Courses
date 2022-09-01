function colorize() {
    // Solution 1
    // let evenRows = document.querySelectorAll('tr:nth-child(even)');
    // evenRows.forEach((r) => r.style.backgroundColor = 'teal');

    // Solution 2
    let evenRows = document.getElementsByTagName('tr');
    let evenRowsArr = Array.from(evenRows);
    evenRowsArr.forEach((e, index) => {
        if (index % 2 != 0) {
            e.style.backgroundColor = 'teal';
        }
    });
}