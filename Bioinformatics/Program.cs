//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using System;
using System.Threading.Tasks;


namespace Bioinformatics
{
    //By processing each DNA segment in parallel, the overall time for sequencing and analysis is considerably reduced.
    class Program
    {
        static void Main(string[] args)
        {
            string[] dnaSegments = new string[] { "AGTC", "GATTACA", "CGTA" };

            Parallel.ForEach(dnaSegments, segment =>
            {
                ProcessSegment(segment);
            });

            Console.WriteLine("DNA sequencing completed.");
        }

        static void ProcessSegment(string segment)
        {
            // Simulate DNA segment processing
            Task.Delay(100).Wait();

            Console.WriteLine($"Processed segment: {segment}");
        }
    }
}

