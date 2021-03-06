import java.util.Scanner;

public class Selling {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());

        String[][] matrix = new String[n][n];

        int myRow = -1;
        int myCol = -1;

        int firstPillarRow = -1;
        int firstPillarCol = -1;

        int secondPillarRow = -1;
        int secondPillarCol = -1;

        int money = 0;
        boolean isOutside = false;

        for (int row = 0; row < matrix.length; row++) {
            String line = scanner.nextLine();
            for (int col = 0; col < matrix[row].length; col++) {
                matrix[row][col] = String.valueOf(line.charAt(col));
                if (matrix[row][col].equals("S")) {
                    myRow = row;
                    myCol = col;
                } else if (matrix[row][col].equals("O")) {
                    if (firstPillarRow == -1) {
                        firstPillarRow = row;
                        firstPillarCol = col;
                    } else {
                        secondPillarRow = row;
                        secondPillarCol = col;
                    }
                }
            }
        }

        String command = scanner.nextLine();
        while (true) {
            matrix[myRow][myCol] = "-";
            switch (command) {
                case "up":
                    myRow--;
                    break;
                case "down":
                    myRow++;
                    break;
                case "right":
                    myCol++;
                    break;
                case "left":
                    myCol--;
                    break;
            }

            if (!isInside(myRow, myCol, matrix)) {
                isOutside = true;
                break;
            }
            if (matrix[myRow][myCol].equals("O")) {
                matrix[myRow][myCol] = "-";

                if (myRow == firstPillarRow && myCol == firstPillarCol) {
                    myRow = secondPillarRow;
                    myCol = secondPillarCol;
                } else {
                    myRow = firstPillarRow;
                    myCol = firstPillarCol;
                }
            } else if (!matrix[myRow][myCol].equals("-")) {
                money += Integer.parseInt(matrix[myRow][myCol]);
            }
            matrix[myRow][myCol] = "S";
            if (money >= 50) {
                break;
            }
            command = scanner.nextLine();
        }

        if (isOutside) {
            System.out.println("Bad news, you are out of the bakery.");
        } else {
            System.out.println("Good news! You succeeded in collecting enough money!");
        }
        System.out.println("Money: " + money);
        printMatrix(matrix);
    }

    private static boolean isInside(int row, int col, String[][] matrix) {
        return row >= 0 && row < matrix.length &&
                col >= 0 && col < matrix.length;
    }

    private static void printMatrix(String[][] matrix) {
        for (int row = 0; row < matrix.length; row++) {
            for (int col = 0; col < matrix[row].length; col++) {
                System.out.print(matrix[row][col]);
            }
            System.out.println();
        }
    }
}
