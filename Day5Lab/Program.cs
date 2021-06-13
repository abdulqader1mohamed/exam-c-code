using System;
/// <summary>
/// This is lab5 on Events using My Own Delegate :::
/// if exam is started the event would fire ::::
/// </summary>
namespace Day5Lab
{
    public class myEventArgs
    {
        public DateTime dt;
        public myEventArgs(DateTime dt)
        {
            this.dt = dt;
        }
    }
    public enum ExamMode
    {
        start, end
    }

    public delegate void mydel(Exam ex, myEventArgs e);
    public class Exam
    {
        public int ExamId { get; set; }
     
        public int durationOfExam { get; set; }

        public string subjectName { get; set; }
        ExamMode examMode;
        public ExamMode _ExamMode
        {
            get { return examMode; }
            set
            {
                examMode = value;
                if (ExamMode.start == value)
                {
                    if (myEvent != null)
                        myEvent(this, new myEventArgs(DateTime.Now));
                }
            }
        }
        public Exam(int id, int duration, string subject, ExamMode examMode)
        {
            this.ExamId = id;
            this.durationOfExam = duration;
            this.subjectName = subject;
            this.examMode = examMode;

            Student s = new Student();
            Staff f = new Staff();
            myEvent += s.print;
            myEvent += f.print;
        }
        public event mydel myEvent;

    }
    public class Student
    {
        public void print(Exam ex, myEventArgs e)
        {
            Console.WriteLine($"examID :{ex.ExamId}  subject :{ex.subjectName}  exam mode: { ex._ExamMode}   exam duration :{ ex.durationOfExam} ");
            Console.WriteLine($"time's now  {e.dt} ");
        }
    }
    public class Staff
    {
        public void print(Exam ex, myEventArgs e)
        {
            Console.WriteLine($" examID :{ex.ExamId}  subject :{ex.subjectName}  exam mode: { ex._ExamMode}   exam duration :{ ex.durationOfExam} ");
            Console.WriteLine($"time's now  {e.dt}");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Exam ex = new Exam(1, 50, "OOP", ExamMode.start);

            Console.WriteLine("Enter exam mode :  0 | start \t 1 | end");

            string examModeValue = Console.ReadLine();

            ex._ExamMode = (ExamMode)Enum.Parse(typeof(ExamMode), examModeValue);

        }
    }
}
