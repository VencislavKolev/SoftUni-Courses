function sortingNumbers(input) {
    input.sort((a, b) => a - b);

    let smallest = input.splice(0, input.length / 2);
    let biggest = input.reverse();
    let sorted = [];

    for (let i = 0; i < smallest.length; i++) {
        sorted.push(smallest[i]);
        sorted.push(biggest[i]);
    }

    if (biggest.length > smallest.length) {
        sorted.push(biggest.pop())
    }
    console.log(sorted);
    return sorted;
}

sortingNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56])
sortingNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56, 100])