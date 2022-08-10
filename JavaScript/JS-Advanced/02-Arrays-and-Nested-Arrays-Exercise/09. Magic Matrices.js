function magicMatrix(matrix) {

    let rowSum = 0;
    let colSum = 0;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix.length; col++) {
            const rowVal = matrix[row][col];
            rowSum += rowVal;

            const colVal = matrix[col][row]
            colSum += colVal;
        }
        if (rowSum !== colSum) {
            // console.log(false)
            return false;
        }
    }
    // console.log(true);
    return true;
}

magicMatrix([[4, 5, 6],
[6, 5, 4],
[5, 5, 5]]
)

magicMatrix([[1, 0, 0],
[0, 0, 1],
[0, 1, 0]]
)

magicMatrix([[11, 32, 45],
[21, 0, 1],
[21, 1, 1]]
)