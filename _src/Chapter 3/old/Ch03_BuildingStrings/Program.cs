using System;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using static System.Console;
using static System.Diagnostics.Process;

namespace Ch03_BuildingStrings
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
            WriteLine("");

            int[] numbers = Enumerable.Range(1, 10000).ToArray();

            Recorder.Start();
            WriteLine("  Using string");
            string s = "";
            for (int i = 0; i < numbers.Length; i++)
            {
                s += numbers[i] + ", ";
            }
            Recorder.Stop();
            WriteLine("");

            Recorder.Start();
            WriteLine("  Using StringBuilder");
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < numbers.Length; i++)
            {
                builder.Append(numbers[i]);
                builder.Append(", ");
            }
            Recorder.Stop();
            WriteLine("");
        }
    }
}
