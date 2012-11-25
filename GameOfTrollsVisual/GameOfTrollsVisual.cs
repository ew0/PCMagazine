using System;
using System.IO;

class GameOfTrollsVisual
{
    private static int C;
    private static int N;
    private static int[,] matrix;
    private static int positionRow;
    private static int positionCol;
    private static int putValue;
    private static int takeValue;
    private static int singlePositonValue;
    private static int maxValue;
    private static int currentPosition;
    private static bool colLeft;
    private static bool colRight;
    private static bool rowUp;
    private static bool rowDown;
    private static bool endOfProgram;
    private static int action;
    private static int rounds;
    private static int startPoints;
    private static int turnPoints;
    private static int finalPoints;

    private static void FileReader()
    {
        string input;
        string[] rowRead;

        TextReader reader = new StreamReader("input.txt");
        input = reader.ReadLine();
        C = int.Parse(input);
        input = reader.ReadLine();
        N = int.Parse(input);
        matrix = new int[N, N];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            input = reader.ReadLine();
            rowRead = input.Split(' ');
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                matrix[row, col] = int.Parse(rowRead[col]);
            }
        }

        reader.Close();
    }

    private static void StartPointsSum()
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                startPoints += matrix[row, col];
            }
        }
    }

    private static void ValidatePosition(int row, int col)
    {
        if (row - 1 < 0)
        {
            rowUp = false;
        }
        else
        {
            rowUp = true;
        }
        if (row + 1 > N - 1)
        {
            rowDown = false;
        }
        else
        {
            rowDown = true;
        }
        if (col - 1 < 0)
        {
            colLeft = false;
        }
        else
        {
            colLeft = true;
        }
        if (col + 1 > N - 1)
        {
            colRight = false;
        }
        else
        {
            colRight = true;
        }
    }

    private static void CheckPutValue(int row, int col)
    {
        if (matrix[row, col] == 0)
        {
            return;
        }
        currentPosition = matrix[row, col] + 1;
        putValue = 0;

        if (colLeft && (currentPosition == matrix[row, col - 1]))
        {
            putValue += matrix[row, col - 1];
        }
        if (colRight && (currentPosition == matrix[row, col + 1]))
        {
            putValue += matrix[row, col + 1];
        }
        if (rowUp && (currentPosition == matrix[row - 1, col]))
        {
            putValue += matrix[row - 1, col];
        }
        if (rowDown && (currentPosition == matrix[row + 1, col]))
        {
            putValue += matrix[row + 1, col];
        }
        if (putValue > 0)
        {
            putValue += currentPosition;
        }
    }

    private static void CheckTakeValue(int row, int col)
    {
        if (matrix[row, col] == 0)
        {
            return;
        }
        currentPosition = matrix[row, col] - 1;
        takeValue = 0;

        if (colLeft && (currentPosition == matrix[row, col - 1]))
        {
            takeValue += matrix[row, col - 1];
        }
        if (colRight && (currentPosition == matrix[row, col + 1]))
        {
            takeValue += matrix[row, col + 1];
        }
        if (rowUp && (currentPosition == matrix[row - 1, col]))
        {
            takeValue += matrix[row - 1, col];
        }
        if (rowDown && (currentPosition == matrix[row + 1, col]))
        {
            takeValue += matrix[row + 1, col];
        }
        if (takeValue > 0)
        {
            takeValue += currentPosition;
        }
    }

    private static void SetMaxValue(int row, int col)
    {
        if ((putValue > 0) || (takeValue > 0))
        {
            if (maxValue < putValue)
            {
                maxValue = putValue;
                positionRow = row;
                positionCol = col;
                action = 1;
            }
            if (maxValue < takeValue)
            {
                maxValue = takeValue;
                positionRow = row;
                positionCol = col;
                action = 2;
            }
        }
        else if ((maxValue == 0) && (singlePositonValue < matrix[row, col]))
        {
            singlePositonValue = matrix[row, col];
            positionRow = row;
            positionCol = col;
            action = 3;
        }
    }

    private static void PutOrTake()
    {
        if ((action == 1))
        {
            matrix[positionRow, positionCol]++;
        }
        if (action == 2)
        {
            matrix[positionRow, positionCol]--;
        }
        if ((action == 3) && (matrix[positionRow, positionCol] > 0))
        {
            matrix[positionRow, positionCol]--;
        }
    }

    private static void DestroyTowers()
    {
        if (positionRow == -1 || positionCol == -1)
        {
            endOfProgram = true;
            return;
        }
        ValidatePosition(positionRow, positionCol);

        if ((action == 1) || (action == 2))
        {
            if (colLeft && (matrix[positionRow, positionCol] == matrix[positionRow, positionCol - 1]))
            {
                matrix[positionRow, positionCol - 1] = 0;
            }
            if (colRight && (matrix[positionRow, positionCol] == matrix[positionRow, positionCol + 1]))
            {
                matrix[positionRow, positionCol + 1] = 0;
            }
            if (rowUp && (matrix[positionRow, positionCol] == matrix[positionRow - 1, positionCol]))
            {
                matrix[positionRow - 1, positionCol] = 0;
            }
            if (rowDown && (matrix[positionRow, positionCol] == matrix[positionRow + 1, positionCol]))
            {
                matrix[positionRow + 1, positionCol] = 0;
            }
            matrix[positionRow, positionCol] = 0;
        }
    }

    private static void PrintOutput()
    {
        if (((action == 1)) && (positionRow >= 0))
        {
            rounds++;
            Console.WriteLine("put {0} {1} - turn: {2}", positionRow, positionCol, rounds);
            PrintArray();
        }
        else if (((action == 2) || (action == 3)) && (positionRow >= 0))
        {
            rounds++;
            Console.WriteLine("take {0} {1} - turn: {2}", positionRow, positionCol, rounds);
            PrintArray();
        }
    }

    private static void PrintArray()
    {
        for (int row = 0; row < N; row++)
        {
            Console.Write("{0}::  ", row);
            for (int col = 0; col < N; col++)
            {
                // TEMPORALY!!!
                if (matrix[row, col] == 0)
                {
                    Console.Write(" , ");
                }
                else
                {
                    Console.Write(matrix[row, col] + ", ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    private static void VariablePreparation()
    {
        positionRow = -1;
        positionCol = -1;
        putValue = 0;
        takeValue = 0;
        singlePositonValue = 0;
        maxValue = 0;
        action = 0;
        currentPosition = 0;
    }

    static void Main()
    {
        /*
        да се тества алгоритъма дали работи за по-малко от 3 сек.
        */

        FileReader();
        StartPointsSum();

        Console.WriteLine("Start array: {0} points", startPoints);
        PrintArray();

        for (int counter = 0; counter < C; counter++)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    ValidatePosition(row, col);
                    CheckPutValue(row, col);
                    CheckTakeValue(row, col);
                    SetMaxValue(row, col);
                }
            }
            if (endOfProgram)
            {
                return;
            }
            PutOrTake();
            DestroyTowers();
            PrintOutput();
            VariablePreparation();
        }
    }
}