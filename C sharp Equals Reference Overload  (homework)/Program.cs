using System;

namespace C_sharp_Equals_Reference_Overload___homework_
{
    class Program
    {
        static void Main(string[] args)
        {
                Vector vec1 = new Vector(5, 4);
                Console.WriteLine(vec1);
                Console.WriteLine($"Vector length: {vec1.VectorLength()}");
                Vector vec2 = new Vector(5, 5);
                Console.WriteLine(vec2);
                Console.WriteLine($"Vector1: {vec1} + Vector2: {vec2} is equal = {vec1 + vec2}");
                Console.WriteLine($"Vector1: {vec1} - Vector2: {vec2} is equal = {vec1 - vec2}");
                Console.WriteLine($"Vector1: {vec1} * Vector2: {vec2} is equal = {vec1 * vec2}");
                Console.WriteLine($"Checking if Vector1: {vec1} is equal Vector2: {vec2} : {vec1 == vec2}");
                Console.WriteLine($"Checking if Vector1: {vec1} is not equal Vector2: {vec2} : {vec1 != vec2}");
                Console.WriteLine($"Checking if Vector1: {vec1} is equal Vector2: {vec2} : {vec1.Equals(vec2)}");
                Console.WriteLine($"Hash for Vector1: {vec1.GetHashCode()} \nHash for Vector2: {vec2.GetHashCode()} ");
                Console.WriteLine(vec1.GetHashCode() != vec2.GetHashCode() ? "Objects has different Hashes!" : "Objects has same Hashes!");
                Fraction fr1 = new Fraction(12, 5);
                Console.WriteLine($"Vector1: {vec1} * Fraction1: {fr1} = {vec1 * fr1}");
                Console.WriteLine($"\nVector: {vec1}");
                Console.WriteLine($"++prefix : {++vec1}");
                Console.WriteLine($"postfix++ : {vec1++} and after : {vec1}");
                Console.WriteLine($"--prefix : {--vec1}");
                Console.WriteLine($"postfix-- : {vec1--} and after : {vec1}");
                vec1 = -vec1;
                Console.WriteLine($"\nUnary operation (-vec1) {vec1}");
                Console.WriteLine($"\nTesting overloading TRUE and FAlSE (if vector == 0,0 => FASLE) else (TRUE) :");
                Console.WriteLine($"Vector is {vec1}");
                vec1 = new Vector(1, 0);
                if (vec1)
                    Console.WriteLine("True");
                else
                    Console.WriteLine("False");
                Console.WriteLine($"\nChecking += operation: \nVector1: {vec1} += Vector2: {vec2}");
                vec1 += vec2;
                Console.WriteLine($"Vector1 = {vec1}");
                Console.WriteLine($"\nChecking -= operation: \nVector1: {vec1} -= Vector2: {vec2}");
                vec1 -= vec2;
                Console.WriteLine($"Vector1 = {vec1}");
                double num = 5.3;
                Vector v = (Vector)num;
                Console.WriteLine($"Converting number {num} (implicitly) to Vector {v}");
                Fraction fr3 = new Fraction(15, 2);
                Vector vec4 = new Vector(3, 5);
                try
                {
                    vec4[0] = 100;
                    vec4[1] = 2;
                    Console.WriteLine(vec4); //moment implicit operator double
                    Console.WriteLine($"Indexator get : {vec4["x"]}");
                    Console.WriteLine(vec4.ToString()); //Ok 100/3
                    vec4[1] = 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
        }
    }
}