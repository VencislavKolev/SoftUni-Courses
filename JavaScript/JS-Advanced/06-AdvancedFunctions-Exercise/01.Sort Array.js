function solve(numbers, order) {
    if (order === 'asc') {
        return numbers.sort((a, b) => a - b);
    }
    return numbers.sort((a, b) => b - a);
}

console.log(solve([14, 7, 17, 6, 8], 'asc'))