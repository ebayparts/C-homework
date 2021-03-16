using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_HT_Nullable
{
    class Mark
    {
        DateTime markDate;
        int? grade;
        int lessonNumber = 1;

        public int? Grade
        {
            get => grade;
            set
            {
                int newgrade = value ?? default(int);
                if (newgrade >= 0)
                {
                    this.grade = value;
                    //return;
                }
                else
                    Console.WriteLine("Error. Mark must be a positive value");
                return;
            }
        }
        public DateTime MarkDate
        {
            get => markDate;
            set => markDate = value;
        }
        public int LessonNumber
        {
            get => lessonNumber;
            set => lessonNumber = value;
        }
        public Mark()
        {
            Grade = null;
            MarkDate = new DateTime();
        }
        public Mark(DateTime markDate, int? grade)
        {
            MarkDate = markDate;
            Grade = grade;
        }
    }
    class Student
    {
        string name = "Noname";
        Mark[] marks = new Mark[0];
        public Student(string name = "Noname")
        {
            this.name = name;
        }
        //public Student()
        //{}
        public string Name
        {
            get => name;
            set => name = value;
        }

        public void AddMark(DateTime addedMarkDate, int? newMark)
        {
            Array.Resize(ref marks, marks.Length + 1);
            Mark mark = new Mark(addedMarkDate, newMark);
            marks[marks.Length - 1] = mark;
            if (marks.Length > 1 && marks[marks.Length - 2].MarkDate == marks[marks.Length - 1].MarkDate)
                marks[marks.Length - 1].LessonNumber = marks[marks.Length - 2].LessonNumber + 1;
        }
        public void ChangeMark(DateTime changedMarkDate, int? newMark, int lesson)
        {
            int index;
            index = Array.FindIndex(marks, x => x.MarkDate == changedMarkDate && x.LessonNumber == lesson);
            if (index != -1)
                marks[index].Grade = newMark;
            else
                Console.WriteLine("Bad data");
        }
        public void CancelMark(DateTime cancelledMarkDate, int lesson)
        {
            int index;
            index = Array.FindIndex(marks, x => x.MarkDate == cancelledMarkDate && x.LessonNumber == lesson);
            if (index != -1)
                marks[index].Grade = null;
            else
                Console.WriteLine("Bad data");
        }
        public void PrintAllMarks()
        {
            Console.WriteLine($"Student {Name} has next marks :");
            for (int i = 0; i < marks.Length; i++)
            {
                Console.WriteLine($"Date: {marks[i].MarkDate:dd:MM:yyyy}, Lesson: {marks[i].LessonNumber}, Mark: {marks[i].Grade}");
            }
        }
        public void AverageAllGrades()
        {
            double sum = 0;
            int count = 0;
            foreach (var item in marks)
            {
                sum += (double)item.Grade.GetValueOrDefault();
                count++;
            }
            Console.WriteLine($"Average mark (including 0) is : {Math.Round((sum / count), 2)}");
        }
        public void AverageReceivedGrades()
        {
            double sum = 0;
            int count = 0;
            foreach (var item in marks)
            {
                if (item.Grade != null)
                {
                    sum += (double)item.Grade.GetValueOrDefault();
                    count++;
                }
            }
            Console.WriteLine($"Average received mark is : {Math.Round((sum / count), 2)}");
        }
    }
}
