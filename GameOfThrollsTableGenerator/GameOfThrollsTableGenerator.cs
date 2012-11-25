using System;
using System.IO;
using System.Threading;

class GameOfThrollsTableGenerator
{
    static void Main()
    {
        Console.Write("C: ");
        int C = int.Parse(Console.ReadLine());
        Console.Write("N: ");
        int N = int.Parse(Console.ReadLine());
        Console.Write("Range of numbers from: ");
        int start = int.Parse(Console.ReadLine());
        Console.Write("Range of numbers to: ");
        int end = int.Parse(Console.ReadLine());

        Random random = new Random();
        int[,] matrix = new int[N, N];

        TextWriter writer = new StreamWriter("input.txt");

        writer.WriteLine(C);
        writer.WriteLine(N);

        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < N; col++)
            {
                if (col < N - 1)
                {
                    writer.Write(random.Next(start, end) + " ");
                }
                else
                {
                    if (row < N - 1)
                    {
                        writer.Write(random.Next(start, end) + "\r\n");
                    }
                    else
                    {
                        writer.Write(random.Next(start, end));
                    }
                }
            }
        }

        writer.Close();

        Console.WriteLine("Done!");
    }
}