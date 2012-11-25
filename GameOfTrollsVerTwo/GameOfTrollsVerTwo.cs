using System;
using System.IO;

class GameOfTrollsVerTwo
{
    private static int C;
    private static int N;
    private static int[,] matrix;
    private static int positionRow;
    private static int positionCol;
    private static int putValue;
    private static int takeValue;
    private static int maxValue;
    private static int currentPosition;
    private static bool colLeft;
    private static bool colRight;
    private static bool rowUp;
    private static bool rowDown;
    private static int action;
    private static int counter;

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

        for (int row = 0; row < N; row++)
        {
            input = reader.ReadLine();
            rowRead = input.Split(' ');
            for (int col = 0; col < N; col++)
            {
                matrix[row, col] = int.Parse(rowRead[col]);
            }
        }

        reader.Close();
    }

    private static void VariablePreparation()
    {
        positionRow = -1;
        positionCol = -1;
        putValue = 0;
        takeValue = 0;
        maxValue = 0;
        action = 0;
        currentPosition = 0;
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
        else if (maxValue == 0)
        {

            action = 3;
            positionRow = row;
            positionCol = col;
        }

    }

    private static void PutOrTake()
    {
        if (action == 1)
        {
            matrix[positionRow, positionCol]++;
        }
        if (action == 2)
        {
            matrix[positionRow, positionCol]--;
        }
        if ((action == 3) && (matrix[positionRow, positionCol] >0) )
        {
            matrix[positionRow, positionCol]--;
        }
    }

    private static void DestroyTowers()
    {
        if (positionRow == -1 || positionCol == -1)
        {
            Console.WriteLine("End of the program!!!");
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
            counter++;
            Console.WriteLine("put {0} {1}  turn: {2}", positionRow, positionCol, counter);
            PrintArray();
        }
        else if (((action == 2) || (action == 3)) && (positionRow >= 0))
        {
            counter++;
            Console.WriteLine("take {0} {1} turn: {2}", positionRow, positionCol, counter);
            PrintArray();
        }
    }

    private static void PrintArray()
    {
        for (int row = 0; row < N; row++)
        {
            Console.Write("{0}:::  ", row);
            for (int col = 0; col < N; col++)
            {
                Console.Write(matrix[row, col] + ", ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void Main()
    {
        /*
        не изчислява коректно!!! предпочете 12 пред 14!!!
        да се направи да руши едичини ако не намира високи кули
        да се тества алгоритъма дали работи за по-малко от 3 сек.
        да се направи метод с FileWriter(), който да пише паралелно с отпечатването на колоната - за тестване и приложната част
        */
        double operationTime = (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond;
        FileReader();

        Console.WriteLine("Start array: ");
        PrintArray();

        for (int counter = 0; counter < C; counter++)
        {
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < N; col++)
                {
                    ValidatePosition(row, col);
                    CheckPutValue(row, col);
                    SetMaxValue(row, col);
                    CheckTakeValue(row, col);
                    SetMaxValue(row, col);
                }
            }
            PutOrTake();
            DestroyTowers();
            PrintOutput();
            VariablePreparation();

        }
        Console.WriteLine(((DateTime.Now.Second * 1000) + DateTime.Now.Millisecond) - operationTime);
    }
}