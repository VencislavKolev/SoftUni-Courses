function aggregateElements(elements) {
    calculateSum(elements);
    calculateInverseSum(elements);
    concat(elements)

    function calculateSum(arr) {
        let sum = 0;
        arr.forEach(num => {
            sum += num;
        });
        console.log(sum);
    }

    function calculateInverseSum(arr) {
        let sum = 0;
        arr.forEach(num => {
            sum += 1 / num;
        });
        console.log(sum);
    }

    function concat(arr) {
        console.log(arr.join(""));
    }
}

aggregateElements([1, 2, 3])
aggregateElements([2, 4, 8, 16])