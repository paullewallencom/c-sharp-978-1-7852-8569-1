using System;
using System.Diagnostics;
using System.Linq;
using static System.Console;
using static System.Diagnostics.Process;

namespace Ch03_Monitoring
{
    class Recorder
    {
        static Stopwatch timer = new Stopwatch();
        static long bytesPhysicalBefore = default(long);
        static long bytesVirtualBefore = default(long);

        public static void Start()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            bytesPhysicalBefore = GetCurrentProcess().WorkingSet64;
            bytesVirtualBefore = GetCurrentProcess().VirtualMemorySize64;
            timer.Restart();
        }

        public static void Stop()
        {
            timer.Stop();
            var bytesPhysicalAfter = GetCurrentProcess().WorkingSet64;
            var bytesVirtualAfter = GetCurrentProcess().VirtualMemorySize64;
            WriteLine("  Stopped recording.");
            WriteLine($"  {bytesPhysicalAfter - bytesPhysicalBefore:N0} physical bytes used.");
            WriteLine($"  {bytesVirtualAfter - bytesVirtualBefore:N0} virtual bytes used.");
            WriteLine($"  {timer.Elapsed} time span ellapsed.");
            WriteLine($"  {timer.ElapsedMilliseconds:N0} total milliseconds ellapsed.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine();
            Write("  Press ENTER to start the timer: ");
            ReadLine();
            Recorder.Start();

            int[] largeArrayOfInts = Enumerable.Range(1, 10000).ToArray();

            Write("  Press ENTER to stop the timer: ");
            ReadLine();
            Recorder.Stop();
            WriteLine();
        }
    }
}
