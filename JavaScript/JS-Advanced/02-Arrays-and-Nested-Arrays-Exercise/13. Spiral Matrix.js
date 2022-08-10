function spiral(d1, d2) {
    let lastDigit = d1 * d2;
    let toFill = 1;

    let top = 0;
    let bottom = d1 - 1;
    let left = 0;
    let right = d2 - 1;

    let direction = true;

    let matrix = Array(d1).fill(null).map(() => Array(d2).fill(0));
    // console.table(matrix);

    while (true) {
        fillHorizontal();
        if (toFill > lastDigit) break;
        fillVertical()
        direction = !direction;

        fillHorizontal()
        fillVertical()
        direction = !direction;

        function fillHorizontal() {
            if (direction) {
                for (let i = left; i <= right; i++) {
                    matrix[top][i] = toFill++;
                    // console.table(matrix);
                }
                top++;
            } else {
                for (let i = right; i >= left; i--) {
                    matrix[bottom][i] = toFill++;
                    // console.table(matrix);
                }
                bottom--;
            }
        }

        function fillVertical() {
            if (direction) {
                for (let i = top; i <= bottom; i++) {
                    matrix[i][right] = toFill++;
                    // console.table(matrix);
                }
                right--;
            } else {
                for (let i = bottom; i >= top; i--) {
                    matrix[i][left] = toFill++;
                    // console.table(matrix);
                }
                left++;
            }
        }
    }
    matrix.forEach(x => console.log(x.join(' ')));
}

spiral(5, 5)
spiral(3, 3)