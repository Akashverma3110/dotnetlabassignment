﻿namespace ValueTypes1
{
    internal class Program
    {
        static void Main23()
        {
            MyPoint p = new MyPoint();
            p.A = 100;
            p.B = 344;
            Console.WriteLine(p.A);
            Console.WriteLine(p.X);
            Console.WriteLine(p.GetType());
        }
    }

    public struct MyPoint
    {
        public int A
        {
            get; set;
        }
        public int X;
        private int b;
        public int B
        {
            get { return b; }
            set { b = value; }
        }
        public MyPoint()
        {
            //this.X = 10;
            //this.A = 30;
            //this.b = 0;
            ////this.B = 40;
        }

    }


}

namespace ValueTypes2
{
    class Program
    {
        static void Main()
        {
            //Display1(1);
            Display2(TimeOfDay.Morning);
           // Display2(TimeOfDay.Morning);
            Console.ReadLine();
        }
        static void Display1(int t)
        {
            if (t == 0)
                Console.WriteLine("Good Morning");
            else if (t == 1)
                Console.WriteLine("Good Afternoon");
            else if (t == 2)
                Console.WriteLine("Good Evening");
            else if (t == 3)
                Console.WriteLine("Good Night");
        }
        static void Display2(TimeOfDay t)
        {
            if (t == TimeOfDay.Morning)
                Console.WriteLine("Good Morning");
            else if (t == TimeOfDay.Afternoon)
                Console.WriteLine("Good Afternoon");
            else if (t == TimeOfDay.Evening)
                Console.WriteLine("Good Evening");
            else if (t == TimeOfDay.Night)
                Console.WriteLine("Good Night");
        }
    }

    public enum TimeOfDay //: byte
    {
        Morning = 10,
        Afternoon = 20,
        Evening = 30,
        Night = 40
    }
   
}