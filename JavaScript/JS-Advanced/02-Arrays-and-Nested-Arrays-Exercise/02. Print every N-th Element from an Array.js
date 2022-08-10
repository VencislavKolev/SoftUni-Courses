function printNthElement(arr, number) {
    let result = [];
    for (let i = 0; i < arr.length; i += number) {
        const element = arr[i];
        result.push(element);
    }
    return result;
}

printNthElement(['5', '20', '31', '4', '20'], 2)

printNthElement(['1', '2', '3', '4', '5'], 6)