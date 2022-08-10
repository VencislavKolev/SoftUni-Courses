function ticTacToe(matrix) {
    let board = [
        ['false', 'false', 'false'],
        ['false', 'false', 'false'],
        ['false', 'false', 'false']];

    let p1Sign = 'X';
    let p2Sign = 'O';
    let freeSpace = 9;
    let currentPlayer = p1Sign;
    let turn = 0;

    while (true) {
        let row = Number(matrix[turn][0]);
        let col = Number(matrix[turn][2]);
        turn++;

        if (freeSpace == 0) {
            console.log("The game ended! Nobody wins :(");
            break;
        }
        if (board[row][col] === 'false') {
            board[row][col] = currentPlayer;
            // console.table(board);
            freeSpace--;
        } else {
            console.log('This place is already taken. Please choose another!');
            continue;
        }

        if (isWin()) {
            console.log(`Player ${currentPlayer} wins!`);
            break;
        }
        currentPlayer = currentPlayer === p1Sign ? p2Sign : p1Sign;
        function isWin() {
            return (board[0][0] === currentPlayer && board[0][1] === currentPlayer && board[0][2] === currentPlayer) ||
                (board[1][0] === currentPlayer && board[1][1] === currentPlayer && board[1][2] === currentPlayer) ||
                (board[2][0] === currentPlayer && board[2][1] === currentPlayer && board[2][2] === currentPlayer) ||
                //rows
                (board[0][0] === currentPlayer && board[1][0] === currentPlayer && board[2][0] === currentPlayer) ||
                (board[0][1] === currentPlayer && board[1][1] === currentPlayer && board[2][1] === currentPlayer) ||
                (board[0][2] === currentPlayer && board[1][2] === currentPlayer && board[2][2] === currentPlayer) ||
                //columns
                (board[0][0] === currentPlayer && board[1][1] === currentPlayer && board[2][2] === currentPlayer) ||
                (board[0][2] === currentPlayer && board[1][1] === currentPlayer && board[2][0] === currentPlayer)
            //diagonals
        }
    }
    board.forEach(x => console.log(x.join('\t')))
    // console.table(board);
}

ticTacToe(["0 0",
    "0 0",
    "1 1",
    "0 1",
    "1 2",
    "0 2",
    "2 2",
    "1 2",
    "2 2",
    "2 1"]
)

// ticTacToe(["0 1",
//     "0 0",
//     "0 2",
//     "2 0",
//     "1 0",
//     "1 1",
//     "1 2",
//     "2 2",
//     "2 1",
//     "0 0"]
// )

// ticTacToe(["0 1",
// "0 0",
// "0 2",
// "2 0",
// "1 0",
// "1 2",
// "1 1",
// "2 1",
// "2 2",
// "0 0"]
// )