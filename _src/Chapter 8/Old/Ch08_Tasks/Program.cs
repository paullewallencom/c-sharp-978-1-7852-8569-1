﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Ch08_Tasks
{
    class Program
    {
        static void MethodA()
        {
            WriteLine("Starting Method A...");
            Thread.Sleep(3000); // simulate three seconds of work
            WriteLine("Finished Method A.");
        }
        static void MethodB()
        {
            WriteLine("Starting Method B...");
            Thread.Sleep(2000); // simulate two seconds of work
            WriteLine("Finished Method B.");
        }
        static void MethodC()
        {
            WriteLine("Starting Method C...");
            Thread.Sleep(1000); // simulate one second of work
            WriteLine("Finished Method C.");
        }
        static decimal CallWebService()
        {
            WriteLine("Starting call to web service...");
            Thread.Sleep((new Random()).Next(2000, 4000));
            WriteLine("Finished call to web service...");
            return 89.99M;
        }
        static string CallStoredProcedure(decimal amount)
        {
            WriteLine("Starting call to stored procedure...");
            Thread.Sleep((new Random()).Next(2000, 4000));
            WriteLine("Finished call to stored procedure...");
            return $"12 products cost more than {amount:C}.";
        }
        static void Main(string[] args)
        {
            var timer = Stopwatch.StartNew();

            //WriteLine("Running methods synchronously on one thread.");
            //MethodA();
            //MethodB();
            //MethodC();

            //WriteLine("Running methods asynchronously on multiple threads.");
            //var taskA = new Task(MethodA);
            //taskA.Start();
            //var taskB = Task.Factory.StartNew(MethodB);
            //var taskC = Task.Run(new Action(MethodC));

            //var tasks = new Task[] { taskA, taskB, taskC };
            //Task.WaitAll(tasks);

            WriteLine("Passing the result of one task as an input into another.");
            var taskCallWebServiceAndThenStoredProcedure =
                Task.Factory.StartNew(CallWebService)
                .ContinueWith(previousTask => CallStoredProcedure(previousTask.Result));

            WriteLine($"{taskCallWebServiceAndThenStoredProcedure.Result}");

            WriteLine($"{timer.ElapsedMilliseconds:#,##0} milliseconds elapsed.");
            WriteLine("Press ENTER to end.");
            ReadLine();
        }
    }
}
