using System;
using System.Threading;

namespace MyNamespace
{

    public delegate void AlarmHandler();
    public class AlarmClock
    {
        public event AlarmHandler Alarm;
        public event AlarmHandler Tick;
        public AlarmClock()
        {
            Tick += delegate { Console.WriteLine("Tick-tock."); };
        }
        public int TimeNow { get; set; }
        public int AlarmTime { get; set; }
        public void Start()
        {
            TimeNow = 0;
            while (TimeNow < 60)
            {
                Thread.Sleep(1000);
                TimeNow++;
                Tick();
                if (TimeNow == AlarmTime)
                {
                    Alarm();
                }
            }
        }


    }
    public class User
    {
        public AlarmClock myOwnClock = new AlarmClock();

        public User(int alarmInput)
        {
            myOwnClock.AlarmTime = alarmInput;
            myOwnClock.Alarm += delegate { Console.WriteLine("\a It's " + alarmInput + " now!"); };
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            int setTime = 0;
            while (!int.TryParse(Console.ReadLine(), out setTime) || setTime < 0)
            {
                Console.WriteLine("PLS input a valid value.");
            }

            User firstUser = new User(setTime);
            firstUser.myOwnClock.Start();
        }

    }
}

