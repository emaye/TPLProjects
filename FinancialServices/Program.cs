//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System.Threading.Tasks;

namespace FinancialServices
{
    //In this example, Parallel.For allows concurrent risk calculations for multiple
    //portfolios, reducing the total processing time significantly
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPortfolios = 1000;
            double[] riskValues = new double[numberOfPortfolios];

            Parallel.For(0, numberOfPortfolios, i =>
            {

                riskValues[i] = CalculateRisk(i);

            });

            Console.WriteLine("Risk calculation completed.");
        }

        static double CalculateRisk(int portfolioId)
        {
            // Simulate complex risk calculation
            Task.Delay(100).Wait();

            return new Random().NextDouble() * 100;
        }
    }
}

