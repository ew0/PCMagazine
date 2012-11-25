using System;

class GameOfTrolls
{
    static void Main()
    {
        short C = 40;
        short N = 4;
        short[,] matrix =
        {
            {1, 2, 3, 4},
            {5, 6, 7, 8},
            {9, 1, 8, 7},
            {1, 2, 3, 4},
        };

        int current = -1;
        int putTempSum = 0;
        int takeTempSum = 0;
        int maxSum = 0;
        bool put = true;
        short positionRow = 0;
        short positionCol = 0;
        int result = 0;

        for (short i = 0; i < N; i++)
        {
            for (short j = 0; j < N; j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine("\r\n");

        for (int count = 0; count < C; count++)
        {
            for (short i = 0; i < N; i++)
            {
                for (short j = 0; j < N; j++)
                {
                    current = matrix[i, j];
                    if (current == 0)
                    {
                        break;
                    }


                    // left top corner
                    if (i == 0 && j == 0)
                    {
                        if ((current + 1 == matrix[i, j + 1]) || (current + 1 == matrix[i + 1, j]))
                        {
                            putTempSum = current + 1;

                            if (current + 1 == matrix[i, j + 1])
                            {
                                putTempSum += matrix[i, j + 1];
                            }
                            if (current + 1 == matrix[i + 1, j])
                            {
                                putTempSum += matrix[i + 1, j];
                            }
                        }

                        if ((current - 1 == matrix[i, j + 1]) || (current - 1 == matrix[i + 1, j]))
                        {
                            takeTempSum = current - 1;

                            if (current - 1 == matrix[i, j + 1])
                            {
                                takeTempSum += matrix[i, j + 1];
                            }
                            if (current - 1 == matrix[i + 1, j])
                            {
                                takeTempSum += matrix[i + 1, j];
                            }
                        }

                        if (putTempSum >= takeTempSum && putTempSum > maxSum)
                        {
                            maxSum = putTempSum;
                            positionRow = i;
                            positionCol = j;
                            put = true;
                        }
                        else if (takeTempSum > putTempSum && takeTempSum > maxSum)
                        {
                            maxSum = takeTempSum;
                            positionRow = i;
                            positionCol = j;
                            put = false;
                        }
                    }


                    // right top corner
                    if (i == 0 && j == N - 1)
                    {
                        if ((current + 1 == matrix[i, j - 1]) || (current + 1 == matrix[i + 1, j]))
                        {
                            putTempSum = current + 1;

                            if (current + 1 == matrix[i, j - 1])
                            {
                                putTempSum += matrix[i, j - 1];
                            }
                            if (current + 1 == matrix[i + 1, j])
                            {
                                putTempSum += matrix[i + 1, j];
                            }
                        }

                        if ((current - 1 == matrix[i, j - 1]) || (current - 1 == matrix[i + 1, j]))
                        {
                            takeTempSum = current - 1;

                            if (current - 1 == matrix[i, j - 1])
                            {
                                takeTempSum += matrix[i, j - 1];
                            }
                            if (current - 1 == matrix[i + 1, j])
                            {
                                takeTempSum += matrix[i + 1, j];
                            }
                        }

                        if (putTempSum >= takeTempSum && putTempSum > maxSum)
                        {
                            maxSum = putTempSum;
                            positionRow = i;
                            positionCol = j;
                            put = true;
                        }
                        else if (takeTempSum > putTempSum && takeTempSum > maxSum)
                        {
                            maxSum = takeTempSum;
                            positionRow = i;
                            positionCol = j;
                            put = false;
                        }
                    }


                    // left down corner
                    if (i == N - 1 && j == 0)
                    {
                        if ((current + 1 == matrix[i, j + 1]) || (current + 1 == matrix[i - 1, j]))
                        {
                            putTempSum = current + 1;

                            if (current + 1 == matrix[i, j + 1])
                            {
                                putTempSum += matrix[i, j + 1];
                            }
                            if (current + 1 == matrix[i - 1, j])
                            {
                                putTempSum += matrix[i - 1, j];
                            }
                        }

                        if ((current - 1 == matrix[i, j + 1]) || (current - 1 == matrix[i - 1, j]))
                        {
                            takeTempSum = current - 1;

                            if (current - 1 == matrix[i, j + 1])
                            {
                                takeTempSum += matrix[i, j + 1];
                            }
                            if (current - 1 == matrix[i - 1, j])
                            {
                                takeTempSum += matrix[i - 1, j];
                            }
                        }

                        if (putTempSum >= takeTempSum && putTempSum > maxSum)
                        {
                            maxSum = putTempSum;
                            positionRow = i;
                            positionCol = j;
                            put = true;
                        }
                        else if (takeTempSum > putTempSum && takeTempSum > maxSum)
                        {
                            maxSum = takeTempSum;
                            positionRow = i;
                            positionCol = j;
                            put = false;
                        }
                    }


                    // right down corner
                    if (i == N - 1 && j == N - 1)
                    {
                        if ((current + 1 == matrix[i, j - 1]) || (current + 1 == matrix[i - 1, j]))
                        {
                            putTempSum = current + 1;

                            if (current + 1 == matrix[i, j - 1])
                            {
                                putTempSum += matrix[i, j - 1];
                            }
                            if (current + 1 == matrix[i - 1, j])
                            {
                                putTempSum += matrix[i - 1, j];
                            }
                        }

                        if ((current - 1 == matrix[i, j - 1]) || (current - 1 == matrix[i - 1, j]))
                        {
                            takeTempSum = current - 1;

                            if (current - 1 == matrix[i, j - 1])
                            {
                                takeTempSum += matrix[i, j - 1];
                            }
                            if (current - 1 == matrix[i - 1, j])
                            {
                                takeTempSum += matrix[i - 1, j];
                            }
                        }

                        if (putTempSum >= takeTempSum && putTempSum > maxSum)
                        {
                            maxSum = putTempSum;
                            positionRow = i;
                            positionCol = j;
                            put = true;
                        }
                        else if (takeTempSum > putTempSum && takeTempSum > maxSum)
                        {
                            maxSum = takeTempSum;
                            positionRow = i;
                            positionCol = j;
                            put = false;
                        }
                    }


                    // top side
                    if (i == 0 && j > 0 && j < N - 1)
                    {
                        if ((current + 1 == matrix[i, j - 1]) || (current + 1 == matrix[i, j + 1]) || (current + 1 == matrix[i + 1, j]))
                        {
                            putTempSum = current + 1;

                            if (current + 1 == matrix[i, j - 1])
                            {
                                putTempSum += matrix[i, j - 1];
                            }
                            if (current + 1 == matrix[i, j + 1])
                            {
                                putTempSum += matrix[i, j + 1];
                            }
                            if (current + 1 == matrix[i + 1, j])
                            {
                                putTempSum += matrix[i + 1, j];
                            }
                        }

                        if ((current - 1 == matrix[i, j - 1]) || (current - 1 == matrix[i, j + 1]) || (current - 1 == matrix[i + 1, j]))
                        {
                            takeTempSum = current - 1;

                            if (current - 1 == matrix[i, j - 1])
                            {
                                takeTempSum += matrix[i, j - 1];
                            }
                            if (current - 1 == matrix[i, j + 1])
                            {
                                takeTempSum += matrix[i, j + 1];
                            }
                            if (current - 1 == matrix[i + 1, j])
                            {
                                takeTempSum += matrix[i + 1, j];
                            }
                        }

                        if (putTempSum >= takeTempSum && putTempSum > maxSum)
                        {
                            maxSum = putTempSum;
                            positionRow = i;
                            positionCol = j;
                            put = true;
                        }
                        else if (takeTempSum > putTempSum && takeTempSum > maxSum)
                        {
                            maxSum = takeTempSum;
                            positionRow = i;
                            positionCol = j;
                            put = false;
                        }
                    }


                    // down side
                    if (i == N - 1 && j > 0 && j < N - 1)
                    {
                        if ((current + 1 == matrix[i, j - 1]) || (current + 1 == matrix[i, j + 1]) || (current + 1 == matrix[i - 1, j]))
                        {
                            putTempSum = current + 1;

                            if (current + 1 == matrix[i, j - 1])
                            {
                                putTempSum += matrix[i, j - 1];
                            }
                            if (current + 1 == matrix[i, j + 1])
                            {
                                putTempSum += matrix[i, j + 1];
                            }
                            if (current + 1 == matrix[i - 1, j])
                            {
                                putTempSum += matrix[i - 1, j];
                            }
                        }

                        if ((current - 1 == matrix[i, j - 1]) || (current - 1 == matrix[i, j + 1]) || (current - 1 == matrix[i - 1, j]))
                        {
                            takeTempSum = current - 1;

                            if (current - 1 == matrix[i, j - 1])
                            {
                                takeTempSum += matrix[i, j - 1];
                            }
                            if (current - 1 == matrix[i, j + 1])
                            {
                                takeTempSum += matrix[i, j + 1];
                            }
                            if (current - 1 == matrix[i - 1, j])
                            {
                                takeTempSum += matrix[i - 1, j];
                            }
                        }

                        if (putTempSum >= takeTempSum && putTempSum > maxSum)
                        {
                            maxSum = putTempSum;
                            positionRow = i;
                            positionCol = j;
                            put = true;
                        }
                        else if (takeTempSum > putTempSum && takeTempSum > maxSum)
                        {
                            maxSum = takeTempSum;
                            positionRow = i;
                            positionCol = j;
                            put = false;
                        }
                    }


                    // left side
                    if (i > 0 && i < N - 1 && j == 0)
                    {
                        if ((current + 1 == matrix[i, j + 1]) || (current + 1 == matrix[i - 1, j]) || (current + 1 == matrix[i + 1, j]))
                        {
                            putTempSum = current + 1;

                            if (current + 1 == matrix[i, j + 1])
                            {
                                putTempSum += matrix[i, j + 1];
                            }
                            if (current + 1 == matrix[i - 1, j])
                            {
                                putTempSum += matrix[i - 1, j];
                            }
                            if (current + 1 == matrix[i + 1, j])
                            {
                                putTempSum += matrix[i + 1, j];
                            }
                        }

                        if ((current - 1 == matrix[i, j + 1] || (current - 1 == matrix[i - 1, j]) || (current - 1 == matrix[i + 1, j])))
                        {
                            takeTempSum = current - 1;

                            if (current - 1 == matrix[i, j + 1])
                            {
                                takeTempSum += matrix[i, j + 1];
                            }
                            if (current - 1 == matrix[i - 1, j])
                            {
                                takeTempSum += matrix[i - 1, j];
                            }
                            if (current - 1 == matrix[i + 1, j])
                            {
                                takeTempSum += matrix[i + 1, j];
                            }
                        }

                        if (putTempSum >= takeTempSum && putTempSum > maxSum)
                        {
                            maxSum = putTempSum;
                            positionRow = i;
                            positionCol = j;
                            put = true;
                        }
                        else if (takeTempSum > putTempSum && takeTempSum > maxSum)
                        {
                            maxSum = takeTempSum;
                            positionRow = i;
                            positionCol = j;
                            put = false;
                        }
                    }


                    // right side
                    if (i > 0 && i < N - 1 && j == N - 1)
                    {
                        if ((current + 1 == matrix[i, j - 1]) || (current + 1 == matrix[i - 1, j]) || (current + 1 == matrix[i + 1, j]))
                        {
                            putTempSum = current + 1;

                            if (current + 1 == matrix[i, j - 1])
                            {
                                putTempSum += matrix[i, j - 1];
                            }
                            if (current + 1 == matrix[i - 1, j])
                            {
                                putTempSum += matrix[i - 1, j];
                            }
                            if (current + 1 == matrix[i + 1, j])
                            {
                                putTempSum += matrix[i + 1, j];
                            }
                        }

                        if ((current - 1 == matrix[i, j - 1] || (current - 1 == matrix[i - 1, j]) || (current - 1 == matrix[i + 1, j])))
                        {
                            takeTempSum = current - 1;

                            if (current - 1 == matrix[i, j - 1])
                            {
                                takeTempSum += matrix[i, j - 1];
                            }
                            if (current - 1 == matrix[i - 1, j])
                            {
                                takeTempSum += matrix[i - 1, j];
                            }
                            if (current - 1 == matrix[i + 1, j])
                            {
                                takeTempSum += matrix[i + 1, j];
                            }
                        }

                        if (putTempSum >= takeTempSum && putTempSum > maxSum)
                        {
                            maxSum = putTempSum;
                            positionRow = i;
                            positionCol = j;
                            put = true;
                        }
                        else if (takeTempSum > putTempSum && takeTempSum > maxSum)
                        {
                            maxSum = takeTempSum;
                            positionRow = i;
                            positionCol = j;
                            put = false;
                        }
                    }


                    // middle
                    if (i > 0 && i < N - 1 && j > 0 && j < N - 1)
                    {
                        if ((current + 1 == matrix[i, j - 1]) || (current + 1 == matrix[i, j + 1]) || (current + 1 == matrix[i - 1, j]) || (current + 1 == matrix[i + 1, j]))
                        {
                            putTempSum = current + 1;

                            if (current + 1 == matrix[i, j - 1])
                            {
                                putTempSum += matrix[i, j - 1];
                            }
                            if (current + 1 == matrix[i, j + 1])
                            {
                                putTempSum += matrix[i, j + 1];
                            }
                            if (current + 1 == matrix[i - 1, j])
                            {
                                putTempSum += matrix[i - 1, j];
                            }
                            if (current + 1 == matrix[i + 1, j])
                            {
                                putTempSum += matrix[i + 1, j];
                            }
                        }

                        if ((current - 1 == matrix[i, j + 1]) || (current - 1 == matrix[i + 1, j]))
                        {
                            takeTempSum = current - 1;

                            if (current - 1 == matrix[i, j - 1])
                            {
                                takeTempSum += matrix[i, j - 1];
                            }
                            if (current - 1 == matrix[i, j + 1])
                            {
                                takeTempSum += matrix[i, j + 1];
                            }
                            if (current - 1 == matrix[i - 1, j])
                            {
                                takeTempSum += matrix[i - 1, j];
                            }
                            if (current - 1 == matrix[i + 1, j])
                            {
                                takeTempSum += matrix[i + 1, j];
                            }
                        }

                        if (putTempSum >= takeTempSum && putTempSum > maxSum)
                        {
                            maxSum = putTempSum;
                            positionRow = i;
                            positionCol = j;
                            put = true;
                        }
                        else if (takeTempSum > putTempSum && takeTempSum > maxSum)
                        {
                            maxSum = takeTempSum;
                            positionRow = i;
                            positionCol = j;
                            put = false;
                        }
                    }
                }
            }

            if (put && positionRow >= 0)
            {
                Console.WriteLine("\r\nput {0} {1}", positionRow, positionCol);
                current = matrix[positionRow, positionCol] + 1;
                result += current;
                matrix[positionRow, positionCol] = 0;
            }
            else if (!put && positionRow >= 0)
            {
                Console.WriteLine("\r\ntake {0} {1}", positionRow, positionCol);
                current = matrix[positionRow, positionCol] - 1;
                result += current;
                matrix[positionRow, positionCol] = 0;
            }

            // left top corner
            if (positionRow == 0 && positionCol == 0)
            {
                if (current == matrix[positionRow, positionCol + 1])
                {
                    matrix[positionRow, positionCol + 1] = 0;
                    result += current;
                }
                if (current == matrix[positionRow + 1, positionCol])
                {
                    matrix[positionRow + 1, positionCol] = 0;
                    result += current;
                }
            }

            // right top corner
            if (positionRow == 0 && positionCol == N - 1)
            {
                if (current == matrix[positionRow, positionCol - 1])
                {
                    matrix[positionRow, positionCol - 1] = 0;
                    result += current;
                }
                if (current == matrix[positionRow + 1, positionCol])
                {
                    matrix[positionRow + 1, positionCol] = 0;
                    result += current;
                }
            }

            // left down corner
            if (positionRow == N - 1 && positionCol == 0)
            {
                if (current == matrix[positionRow, positionCol + 1])
                {
                    matrix[positionRow, positionCol + 1] = 0;
                    result += current;
                }
                if (current == matrix[positionRow - 1, positionCol])
                {
                    matrix[positionRow - 1, positionCol] = 0;
                    result += current;
                }
            }

            // right down corner
            if (positionRow == N - 1 && positionCol == N - 1)
            {
                if (current == matrix[positionRow, positionCol - 1])
                {
                    matrix[positionRow, positionCol - 1] = 0;
                    result += current;
                }
                if (current == matrix[positionRow - 1, positionCol])
                {
                    matrix[positionRow - 1, positionCol] = 0;
                    result += current;
                }
            }

            // top side
            if (positionRow == 0 && positionCol > 0 && positionCol < N - 1)
            {
                if (current == matrix[positionRow, positionCol - 1])
                {
                    matrix[positionRow, positionCol - 1] = 0;
                    result += current;
                }
                if (current == matrix[positionRow, positionCol + 1])
                {
                    matrix[positionRow, positionCol + 1] = 0;
                    result += current;
                }
                if (current == matrix[positionRow + 1, positionCol])
                {
                    matrix[positionRow + 1, positionCol] = 0;
                    result += current;
                }
            }

            // down side
            if (positionRow == N - 1 && positionCol > 0 && positionCol < N - 1)
            {
                if (current == matrix[positionRow, positionCol - 1])
                {
                    matrix[positionRow, positionCol - 1] = 0;
                    result += current;
                }
                if (current == matrix[positionRow, positionCol + 1])
                {
                    matrix[positionRow, positionCol + 1] = 0;
                    result += current;
                }
                if (current == matrix[positionRow - 1, positionCol])
                {
                    matrix[positionRow - 1, positionCol] = 0;
                    result += current;
                }
            }

            // left side
            if (positionRow > 0 && positionRow < N - 1 && positionCol == 0)
            {
                if (current == matrix[positionRow, positionCol + 1])
                {
                    matrix[positionRow, positionCol + 1] = 0;
                    result += current;
                }
                if (current == matrix[positionRow - 1, positionCol])
                {
                    matrix[positionRow - 1, positionCol] = 0;
                    result += current;
                }
                if (current == matrix[positionRow + 1, positionCol])
                {
                    matrix[positionRow + 1, positionCol] = 0;
                    result += current;
                }
            }

            // right side
            if (positionRow > 0 && positionRow < N - 1 && positionCol == N - 1)
            {
                if (current == matrix[positionRow, positionCol - 1])
                {
                    matrix[positionRow, positionCol - 1] = 0;
                    result += current;
                }
                if (current == matrix[positionRow - 1, positionCol])
                {
                    matrix[positionRow - 1, positionCol] = 0;
                    result += current;
                }
                if (current == matrix[positionRow + 1, positionCol])
                {
                    matrix[positionRow + 1, positionCol] = 0;
                    result += current;
                }
            }

            // top side
            if (positionRow > 0 && positionRow < N - 1 && positionCol > 0 && positionCol < N - 1)
            {
                if (current == matrix[positionRow, positionCol - 1])
                {
                    matrix[positionRow, positionCol - 1] = 0;
                    result += current;
                }
                if (current == matrix[positionRow, positionCol + 1])
                {
                    matrix[positionRow, positionCol + 1] = 0;
                    result += current;
                }
                if (current == matrix[positionRow - 1, positionCol])
                {
                    matrix[positionRow - 1, positionCol] = 0;
                    result += current;
                }
                if (current == matrix[positionRow + 1, positionCol])
                {
                    matrix[positionRow + 1, positionCol] = 0;
                    result += current;
                }
            }

            current = 0;
            positionRow = 0;
            positionCol = 0;
            putTempSum = 0;
            takeTempSum = 0;
            maxSum = 0;

            for (short m = 0; m < N; m++)
            {
                for (short n = 0; n < N; n++)
                {
                    Console.Write(matrix[m, n]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\r\n");
        }

        result -= C;
        Console.WriteLine("Points: {0}", result);
    }
}