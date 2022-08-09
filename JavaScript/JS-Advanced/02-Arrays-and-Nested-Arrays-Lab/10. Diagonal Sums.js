function diagonalSums(matrix) {
    let mainDiagonal = 0;
    let secondaryDiagonal = 0;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            const element = matrix[row][col];
            if (row == col) {
                mainDiagonal += element;
            }
            if (col == matrix[row].length - 1 - row) {
                secondaryDiagonal += element;
            }
        }
    }
    console.log(`${mainDiagonal} ${secondaryDiagonal}`);
}

diagonalSums([[20, 40], [10, 60]])
diagonalSums([[3, 5, 17], [-1, 7, 14], [1, -8, 89]])