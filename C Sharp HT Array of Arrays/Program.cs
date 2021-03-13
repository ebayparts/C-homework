using System;
namespace C_Sharp_HT_Array_of_Arrays
{
    class Program
    {
        static void FillRandJugged(int[][] arr, int left = 0, int right = 100) //// ??
        {
            Random rnd = new Random(); // srand(base)
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = rnd.Next(left, right + 1);
                }

            }
        }
        static int[][] CreateJugged(params int[] cols)
        {
            int[][] m = new int[cols.Length][];
            for (int i = 0; i < m.Length; i++)
            {
                m[i] = new int[cols[i]];
            }
            return m;
        }
        static void ReverseByRaws(int[][] m)
        {
            for (int i = 0, j = m.Length - 1; i < j; i++, --j)
            {
                var tmp = m[i];
                m[i] = m[j];
                m[j] = tmp;
            }
        }
        static void PrintJugged(int[][] matrix)
        {
            Console.WriteLine("Printing matrix:");
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write($"{matrix[i][j],-10}");
                }
                Console.WriteLine();
            }
        }
        static void MoveRowUp(int[][] m, int movedRow, int difference)
        {
            if (movedRow > m.Length - 1 || difference > movedRow)
                Console.WriteLine($"MovedRow can not be more than numeration of last row of matrix: {m.Length - 1}" +
                    $"\nand you can not move upper row that is already upper: {movedRow} " +
                    $"must be not less than difference range: {difference}");
            else
            {
                for (int i = movedRow - 1, j = movedRow; j > m.Length; i--, j--)
                {
                    var tmp = m[i];
                    m[i] = m[j];
                    m[j] = tmp;
                }
            }
        }
        static void MoveRowDown(int[][] m, int movedRow, int difference)
        {
            if (movedRow > m.Length - 2 || movedRow < 0 || difference + movedRow > m.Length - 1)
                Console.WriteLine($"MovedRow can not be lower than numeration of first row of matrix: 0" +
                    $"\nand it can not be more than last row-1: {m.Length - 2}" +
                    $"\nand you can not move lower row that is already lower: {movedRow} " +
                    $"must be not less than difference range: {difference}");
            else
            {
                for (int i = movedRow + 1, j = movedRow; j < movedRow + difference; i++, j++)
                {
                    var tmp = m[i];
                    m[i] = m[j];
                    m[j] = tmp;
                }
            }
        }
        static int[][] DeleteRow(ref int[][] m, int deleteRow)
        {
            if (deleteRow > m.Length - 1 || deleteRow < 0)
            {
                Console.WriteLine($"You cant delete nonexistent row, please chose between 0 and {m.Length - 1}.");
                return m;
            }
            if (deleteRow == m.Length - 1)
            {
                Array.Resize(ref m, m.Length - 1);
                return m;
            }
            else
            {
                for (int i = deleteRow, j = deleteRow + 1; j < m.Length; i++, j++)
                {
                    var tmp = m[i];
                    m[i] = m[j];
                    m[j] = tmp;
                }
                Array.Resize(ref m, m.Length - 1);
                return m;
            }
        }
        static void AddElementToRows(ref int[][] m, int addedElement)
        {
            for (int i = 0; i < m.Length; ++i)
            {
                Array.Resize(ref m[i], m[i].Length + 1);
                m[i][m[i].Length - 1] = addedElement;
            }
        }
        static void Main(string[] args)
        {
            int[][] matrix = CreateJugged(1, 2, 3, 4, 5, 6);
            FillRandJugged(matrix, 0, 100);
            PrintJugged(matrix);
            Console.WriteLine();
            ReverseByRaws(matrix);
            PrintJugged(matrix);
            MoveRowUp(matrix, 4, 3);
            PrintJugged(matrix);
            MoveRowDown(matrix, 1, 2);
            PrintJugged(matrix);
            Console.WriteLine("Deleting one row:");
            DeleteRow(ref matrix, 4);
            PrintJugged(matrix);
            AddElementToRows(ref matrix, 0);
            PrintJugged(matrix);
        }
    }
}

