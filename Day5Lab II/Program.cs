using System;
/// <summary>
/// This is lab5 on Events using Event Handler ::::
/// if exam is started the event would fire ::::
/// </summary>
namespace Day5Lab_II
{
    enum ExamMode
    {
        start, end
    }
    class myEventArgs
    {
        public DateTime dt { get; set; }
        public myEventArgs(DateTime dt)
        {
            this.dt = dt;
        }
    }
    class Exam
    {
        public int id { get; set; }
        public string subject { get; set; }
        public int duration { get; set; }
        public ExamMode mode;
        public ExamMode examMode
        {
            get { return mode; }
            set
            {
                mode = value;
                if (value == ExamMode.start)
                {
                    if (myEvent != null)
                        myEvent(this, new myEventArgs(DateTime.Now));
                }

            }
        }

        public Exam(int id,  string subject, int duration , ExamMode mode)
        {
            this.id = id;
            this.subject = subject;
            this.duration = duration;
            this.mode = mode;

            Student s = new Student();
            myEvent += s.print;
        }


        public event EventHandler<myEventArgs> myEvent;
    }
    class Student
    {
        public void print(object obj , myEventArgs e)
        {
            Exam ex = obj as Exam;
            Console.WriteLine($"exam {ex.examMode}ed duration: {ex.duration} hours   examID {ex.id} Subject: {ex.subject}\t time's now {e.dt}");           
        }
    }

    class Staff
    {
        public static void print(Object obj, myEventArgs e)
        {
            Exam ex = obj as Exam;
            Console.WriteLine($"exam {ex.examMode}ed duration: {ex.duration} hours   examID: {ex.id} Subject: {ex.subject}\t time's now {e.dt}");
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Exam ex = new Exam(101, "Math", 3, ExamMode.start);

            ex.myEvent +=  Staff.print;

            //   ex.examMode = ExamMode.start;
            Console.WriteLine("Enter Exam Mode : 0 | Started \t 1 | end ");
            ex.examMode = (ExamMode)Enum.Parse(typeof(ExamMode), Console.ReadLine());
        }
    }
}
