function biggestElement(nestedArrays) {
    let maxElement = nestedArrays[0][0];
    for (const array of nestedArrays) {
        for (const value of array) {
            if (value > maxElement) {
                maxElement = value;
            }
        }
    }
    console.log(maxElement);
}

biggestElement([[20, 50, 10], [8, 33, 145]])
biggestElement([[3, 5, 7, 12], [-1, 4, 33, 2], [8, 3, 0, 4]])