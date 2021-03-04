using System;
using System.Linq;

namespace Arrays_Classwork
{
    class Program
    {
        void Swap<T>(ref T one, ref T two)
        {
            T tmp = one;
            one = two;
            two = tmp;
        }
        static void FillRand(int[] arr, int left = 0, int right = 100)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(left, right + 1);
            }
        }
        static void PrintArray(int[] arr, string prompt = "")
        {
            Console.WriteLine(prompt);
            foreach (var elem in arr)
            {
                Console.Write(elem + "\t");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            ////////////1
            Console.WriteLine("First task:");
            ///
            int[] arr = null;
            arr = new int[7];
            arr[0] = 1;
            arr[1] = 20;
            arr[2] = -4;
            arr[3] = -6;
            arr[4] = -7;
            arr[5] = 10;
            arr[6] = 100;
            int[] arr1 = Array.FindAll(arr, (int e) => { return e < 0; });
            int[] arr2 = Array.FindAll(arr, (int e) => { return e > 0; });
            arr1.CopyTo(arr, 0);
            arr2.CopyTo(arr, 3);
            Console.WriteLine("Array after replacing elements:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine("");

            //////////////2
            Console.WriteLine("\nSecond task:");
            Console.WriteLine("Enter array size : ");
            int size;
            while (!int.TryParse(Console.ReadLine(), out size))
            {
                Console.WriteLine("Wrong size! Try again!");
            }
            arr = new int[size];
            FillRand(arr);
            PrintArray(arr, "Array after filling with randomies: ");
            int searchable;
            Console.WriteLine("Enter number to count : ");
            while (!int.TryParse(Console.ReadLine(), out searchable))
            {
                Console.WriteLine("Wrong size! Try again!");
            }
            Console.WriteLine($"Count of found numbers : {arr.Count(x => x == searchable)}");

            ////////////////////////3
            Console.WriteLine("\nThird task:");
            int minIndex, maxIndex;
            maxIndex = Array.IndexOf(arr, arr.Max());
            minIndex = Array.IndexOf(arr, arr.Min());
            int sum = 0;
            if (maxIndex < minIndex)
            {
                Program p = new Program();
                p.Swap(ref maxIndex, ref minIndex);
            }
            for (int i = minIndex + 1; i < maxIndex; i++)
            {
                sum += arr[i];
            }
            Console.WriteLine($"Sum of elements between max and min is {sum}");

            ////////////////////////4
            Console.WriteLine("\nFourth task:");
            int sumEven = 0;
            int sumOneDigit = 0;
            foreach (var item in arr)
            {
                if (item % 2 == 0)
                    sumEven += item;
                if (item > 0 && item < 10)
                    sumOneDigit += item;
            }
            Console.WriteLine($"Sum of even numbers in array: {sumEven}, sum of one digit numbers: {sumOneDigit}");

            ////////////////////////5
            Console.WriteLine("\nFifth task:");
            string[] products = { "RAM", "System plate", "SSD", "Processor", "VGA", "PSU" };
            double[] prices = { 170.5, 58.5, 180.7, 153.4, 116.6, 140.8 };
            Array.Sort(prices, products);   // keys     = prices
            for (int i = 0; i < prices.Length; ++i)
            {
                Console.WriteLine($"{products[i],13} {prices[i],7}");
            }
        }
    }
}
