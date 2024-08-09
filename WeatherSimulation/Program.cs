//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Threading.Tasks;


namespace WeatherSimulation
{

    //In this example, Parallel.For is used to run temperature simulations across a grid o
    //f data points concurrently, drastically reducing the time needed to complete
    //the calculation.
    class Program
    {
        static void Main(string[] args)
        {
           int gridSize = 1000;
            double[,] temperatureData = new double[gridSize, gridSize];

            Parallel.For(0, gridSize, i =>
            {
                for (int j = 0; j < gridSize; j++)
                {
                    temperatureData[i, j] = SimulateTemperatureChange(i, j);

                }
            });

            Console.WriteLine("Temperature simulation completed.");

        }


        static double SimulateTemperatureChange(int x, int y)
        {
            // Complex calculation to simulate temperature change
            return Math.Sin(x) * Math.Cos(y);

        }
    }
}
