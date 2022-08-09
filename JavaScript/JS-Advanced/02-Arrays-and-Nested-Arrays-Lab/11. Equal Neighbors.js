function equalNeighbors(matrix) {
    let equalPairs = 0;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            const element = matrix[row][col];
            
            if (matrix.length - 1 === row) {
                checkNeighbor(element, matrix[row][col + 1]);
                continue;
            }
            
            checkNeighbor(element, matrix[row][col + 1]);
            checkNeighbor(element, matrix[row + 1][col])
        }
    }
    console.log(equalPairs);

    function checkNeighbor(element, neighbour) {
        if (element === neighbour) {
            equalPairs++;
        }
    }
}

equalNeighbors(
    [[2, 2, 5, 7, 4],
    [4, 0, 5, 3, 4],
    [2, 5, 5, 4, 2]])

// equalNeighbors([
//     ['2', '3', '4', '7', '0'],
//     ['4', '0', '5', '3', '4'],
//     ['2', '3', '5', '4', '2'],
//     ['9', '8', '7', '5', '4']])

// equalNeighbors(
//     [['test', 'yes', 'yo', 'ho'],
//     ['well', 'done', 'yo', '6'],
//     ['not', 'done', 'yet', '5']])