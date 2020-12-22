﻿using static System.Console;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Diagnostics;

namespace Ch12_LockAndMonitor
{
    class Program
    {
        static Random r = new Random();
        static string Message; // a shared resource
        static int Counter; // another shared resource

        static object conch = new object();

        static void MethodA()
        {
            try
            {
                Monitor.TryEnter(conch, TimeSpan.FromSeconds(10));
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(r.Next(2000));
                    Message += "A";
                    Write(".");
                    Interlocked.Increment(ref Counter);
                }
            }
            finally
            {
                Monitor.Exit(conch);
            }
        }

        static void MethodB()
        {
            try
            {
                Monitor.TryEnter(conch, TimeSpan.FromSeconds(10));
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(r.Next(2000));
                    Message += "B";
                    Write(".");
                    Interlocked.Increment(ref Counter);
                }
            }
            finally
            {
                Monitor.Exit(conch);
            }
        }

        static void Main(string[] args)
        {
            WriteLine("Please wait for the tasks to complete.");
            Stopwatch watch = Stopwatch.StartNew();

            Task a = Task.Factory.StartNew(MethodA);
            Task b = Task.Factory.StartNew(MethodB);

            Task.WaitAll(new Task[] { a, b });
            WriteLine();
            WriteLine($"Results: {Message}.");
            WriteLine($"{watch.ElapsedMilliseconds:#,##0} elapsed milliseconds.");
            WriteLine($"{Counter} string modifications.");
        }
    }
}
