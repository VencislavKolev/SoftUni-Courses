function increasingSubset(array) {
    let result = [];
    let currentMax = array[0];
    result.push(currentMax);
    array.reduce((current, next) => {
        if (current <= next) {
            result.push(next);
            currentMax = next;
        }
        return currentMax;
    })
    console.log(result);
}

increasingSubset([1, 3, 8, 4, 10, 12, 3, 2, 24])

increasingSubset([20, 3, 2, 15, 6, 1])