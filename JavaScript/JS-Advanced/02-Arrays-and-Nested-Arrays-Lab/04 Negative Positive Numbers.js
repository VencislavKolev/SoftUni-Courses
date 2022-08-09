function positiveNegative(input) {
    let array = [];
    for (let i = 0; i < input.length; i++) {
        const element = input[i];
        if (element < 0) {
            array.unshift(element);
        } else {
            array.push(element);
        }
    }
    array.forEach(e => console.log(e));
    // console.log(array.join('\n'));
}

positiveNegative([7, -2, 8, 9])
positiveNegative([3, -2, 0, -1])