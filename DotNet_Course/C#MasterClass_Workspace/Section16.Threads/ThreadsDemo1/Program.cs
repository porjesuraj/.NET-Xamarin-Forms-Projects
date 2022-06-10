using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsDemo1
{
    class Program
    {

        /*#region Thread 3: 
        static void Main(string[] args)
        {
            Console.ReadLine();
        }
        #endregion*/

        #region Thread 5: Thread Join and IsAlive 
        static void Main(string[] args)
        {

            Console.WriteLine("Main Thread Started");

            Thread thread1 = new Thread(Thread1Function);
            Thread thread2 = new Thread(Thread2Function);

            thread1.Start();
            thread2.Start();


            thread1.Join();
            Console.WriteLine("THread1Function done");
            thread2.Join();
            Console.WriteLine("THread2Function done");


            if(thread1.Join(1000))
            {
                Console.WriteLine("THread1Function done in 1 second");

            }else
                Console.WriteLine("THread1Function not done in 1 second");


            Console.WriteLine("Main Thread Ended");


            for (int i = 0; i < 10; i++)
            {
                if (thread1.IsAlive)
                {
                    Console.WriteLine("thread1 is still working");
                    Thread.Sleep(300);
                }
                else
                {
                    Console.WriteLine("thread1 ended");

                }

            }

            

            Console.ReadLine();
        }
        private static void Thread1Function()
        {
            Console.WriteLine("Thread1Function started");
            Thread.Sleep(3000);
            Console.WriteLine("Thread1Function coming back to caller");
        }
        private static void Thread2Function()
        {
            Console.WriteLine("Thread2Function started");
        }
        #endregion

        #region Thread 4: ThreadPool  
        static void Main4(string[] args)
        {


            new Thread(() =>
            {
                Console.WriteLine("Created a Background thread");
            })
            { IsBackground = true }.Start();

            Enumerable.Range(0, 10).ToList().ForEach(f =>
             {
                 new Thread(() =>
                 {
                     ThreadPool.QueueUserWorkItem((o) =>
                     {
                         Console.WriteLine($"Thread number : {Thread.CurrentThread.ManagedThreadId} started");

                         Thread.Sleep(1000);
                         Console.WriteLine($"Thread number : {Thread.CurrentThread.ManagedThreadId} ended");

                     });
                    
                 }).Start();
             });

          
            Console.ReadLine();
        }
        #endregion

        #region Thread 3: Thread Start,End and Completion
        static void Main3(string[] args)
        {

            var taskCompletionSource = new TaskCompletionSource<bool>();

            var thread = new Thread(() =>
            {
                Console.WriteLine($"Thread number : {Thread.CurrentThread.ManagedThreadId} started");

                taskCompletionSource.TrySetResult(true);
                Console.WriteLine($"Thread number : {Thread.CurrentThread.ManagedThreadId} ended");

            });

            thread.Start();

            var test = taskCompletionSource.Task.Result;

            Console.WriteLine("task was done {0}",test);
            Console.ReadLine();
        }
        #endregion

        #region Thread 2: Thread working in parralel 
        static void Main2(string[] args)
        {
            new Thread(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Thread 1");
            }).Start();

             new Thread(() =>
             {
                 Thread.Sleep(1000);
                 Console.WriteLine("Thread 2");
             }).Start();

            new Thread(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Thread 3");
            }).Start();


            Console.ReadLine();
        }

        #endregion

        #region Thread 1:  Create Thread
        static void Main1(string[] args)
        {
            Console.WriteLine("Hello World 1");
            Thread.Sleep(1000);
            Console.WriteLine("Hello World 2");
            Thread.Sleep(1000);
            Console.WriteLine("Hello World 3");
            Thread.Sleep(1000);
            Console.WriteLine("Hello World 4");
            Console.WriteLine("Hello World 5");

            Console.ReadLine();
        }
        #endregion

    }
}
