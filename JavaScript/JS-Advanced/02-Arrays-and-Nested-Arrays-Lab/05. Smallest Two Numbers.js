function smallestNumbers(input) {
    input.sort((a, b) => a - b);
    let result = `${input[0]} ${input[1]}`
    console.log(result);
}

smallestNumbers([30, 15, 50, 5])