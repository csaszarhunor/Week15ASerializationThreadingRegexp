using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleThreadinDemo
{
    class Program
    {
        static void Counting()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("Count: {0}, Thread: {1}", i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            }
        }
        static void Main(string[] args)
        {
            ThreadStart starter = new ThreadStart(Counting);
            Thread thread1 = new Thread(starter);
            Thread thread2 = new Thread(starter);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.ReadKey();
        }
    }
}
