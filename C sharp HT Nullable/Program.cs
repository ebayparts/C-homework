using System;

namespace C_sharp_HT_Nullable
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Oleksandr Zinkovskyi");
            student.PrintAllMarks();
            DateTime markDate1 = new DateTime(2021, 03, 12);
            DateTime markDate2 = new DateTime(2021, 03, 13);
            DateTime markDate3 = new DateTime(2021, 03, 14);

            student.AddMark(markDate1, 100);
            student.AddMark(markDate1, 50);
            student.AddMark(markDate1, 90);
            student.AddMark(markDate2, 65);
            student.AddMark(markDate2, 95);
            student.AddMark(markDate3, 75);
            student.AddMark(markDate3, 85);
            student.PrintAllMarks();
            Console.WriteLine("\nMarks after changing:");
            student.ChangeMark(markDate1, 80, 2);
            student.PrintAllMarks();
            Console.WriteLine("\nMarks after cancelling:");
            student.CancelMark(markDate1, 3);
            student.PrintAllMarks();
            student.AverageReceivedGrades();
            student.AverageAllGrades();
        }
    }
}
