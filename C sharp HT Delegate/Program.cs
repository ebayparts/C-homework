using System;

namespace C_sharp_HT_Delegate
{
    delegate void MyDelegate<T>(ref T one);
    delegate bool MyPredicate(int number);

    static class ArrayExtension
    {
        public static int[] FindAll(this int[] arr, MyPredicate predicate) // Extension method
        {
            int[] result = new int[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (predicate(i))
                {
                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = arr[i];
                }
            }
            return result;
        }
    }
    class Person
    {
        public string Name { get; set; } = "Noname";
        public int Age { get; set; } = 18;
    }
    class Program
    {
        public static int[] MinusOne(int[] arr, MyDelegate<int> deleg)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                deleg(ref arr[i]);
            }
            return arr;
        }

        static void Sort<T>(T[] arr, Comparison<T> comp)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (comp(arr[j], arr[j + 1]) > 0)
                    {
                        var temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int[] arr1 = new[] { 5, 4, 3, 2, 1 };
            MinusOne(arr1, (ref int a) => a--);
            foreach (var item in arr1)
                Console.WriteLine(item);

            Console.WriteLine("Using Extension method : FindAll for Array:");
            int[] res = arr1.FindAll((a) => a % 2 == 0 && a != 0);
            foreach (var item in res)
                Console.WriteLine(item);

            Console.WriteLine("Comparison Bubble sort: (for array of numbers)");
            int[] arr2 = new[] { 15, 114, 2323, 12, 1321 };
            Sort(arr2, (a, b) => a.CompareTo(b));
            foreach (var item in arr2)
                Console.WriteLine(item);

            Console.WriteLine("\nUsing delegate Comparison: Sorting people by Age:---------");
            Person[] people =
            {
                new Person(),
                new Person{Name ="Dima", Age =17},
                new Person{Name ="Olena", Age =16},
                new Person{Name ="Olena", Age =12},
            };

            Comparison<Person> comparison = (e1, e2) => e1.Age.CompareTo(e2.Age);
            Sort(people, comparison);
            foreach (Person p in people)
                Console.WriteLine($"{p.Name,-20} {p.Age,-7}");
        }
    }
}
