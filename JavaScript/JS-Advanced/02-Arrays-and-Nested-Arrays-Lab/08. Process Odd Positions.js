function solve(input) {
    let result = [];
    for (let i = 0; i < input.length; i++) {
        if (i % 2 !== 0) {
            result.push(input[i] * 2);
        }
    }
    result.reverse()
    console.log(result);
}

solve([10, 15, 20, 25])
solve([3, 0, 10, 4, 7, 3])